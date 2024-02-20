namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.AspNetCore.Hosting;
    using SignalR;
    using Core.Contracts;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.AdminModels.ProductStock;
    using static Common.GeneralApplicationConstants;
    using EcommerceApp.Core.Models.Pager;

    [ApiController]
    [Authorize(Roles = AdminRoleName)]
    [Produces("application/json")]
    [Route("api/clothes")]
    public class ClothesController : ControllerBase
    {
        private readonly IProductSevice productSevice;
        private readonly IProductStockService productStockService;
        private readonly IHubContext<NotificationsHub> hubContext;
        private readonly IShoesService shoesService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IPictureService pictureService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ClothesController(IProductSevice productSevice, IProductStockService productStockService,
            IHubContext<NotificationsHub> hubContext, IShoesService shoesService, ICategoryService categoryService,
            IBrandService brandService, IPictureService pictureService, IWebHostEnvironment webHostEnvironment)
        {
            this.productSevice = productSevice;
            this.productStockService = productStockService;
            this.hubContext = hubContext;
            this.shoesService = shoesService;
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.pictureService = pictureService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("LoadAllClothes")]
        public async Task<IActionResult> LoadAllClothes([FromQuery] int pageNumber)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            int allClothesCount = await productSevice.GetAllClothesCountAsync();

            Pager pager = new Pager(allClothesCount, pageNumber, DefaultPageSize);

            var clothes = await productSevice.LoadAllClothesAsync(pager);
            return Ok(new {Clothes = clothes, PagerObject = pager});
        }
        [HttpGet]
        [Route("GetProductToModify")]
        public async Task<IActionResult> GetProductToModify([FromQuery] int productId)
        {
            var product = await productSevice.GetProductToModifyAsync(productId);
            return Ok(product);
        }
        [HttpPut]
        [Route("EditProduct")]
        public async Task<IActionResult> EditProductInfo([FromBody] EditProductModel editProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await productSevice.EditProductAsync(editProductModel);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("AddProductStock")]
        public async Task<IActionResult> AddProductStock([FromBody] AddProductStockModel addProductStockModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await productStockService.IncreaseProductStockQuantity(addProductStockModel);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }

        [HttpPost]
        [Route("Archive")]
        public async Task<IActionResult> Archive([FromBody] ArchiveProductModel archiveProductModel)
        {
            if (archiveProductModel.ProductCategory.ToLower() != "shoes")
            {
                if (!await productSevice.CheckIfProductExistsByIdAsync(archiveProductModel.ProductId))
                {
                    return BadRequest();
                }
                await productSevice.ArchiveProductAsync(archiveProductModel.ProductId);
            }
            else
            {
                if (!await shoesService.CheckIfShoesExistsByIdAsync(archiveProductModel.ProductId))
                {
                    return BadRequest();
                }
                await shoesService.ArchiveShoesAsync(archiveProductModel.ProductId);
            }

            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("Restore")]
        public async Task<IActionResult> Restore([FromBody] ArchiveProductModel archiveProductModel)
        {
            if (archiveProductModel.ProductCategory.ToLower() != "shoes")
            {
                if (!await productSevice.CheckIfProductExistsByIdAsync(archiveProductModel.ProductId))
                {
                    return BadRequest();
                }
                await productSevice.RestoreProductAsync(archiveProductModel.ProductId);
            }
            else
            {
                if (!await shoesService.CheckIfShoesExistsByIdAsync(archiveProductModel.ProductId))
                {
                    return BadRequest();
                }
                await shoesService.RestoreShoesAsync(archiveProductModel.ProductId);
            }
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpGet]
        [Route("LoadCreateProductModel")]
        public async Task<IActionResult> LoadCreateProductModel()
        {
            CreateProductModel model = new CreateProductModel();

            model.Categories = await categoryService.LoadAllCategoriesAsync();
            model.Brands = await brandService.LoadAllBrandsAsync();

            return Ok(model);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductModel createProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            int productId = await productSevice.CreateProductAsync(createProductModel); 
            foreach (var file in createProductModel.ImgFiles)
            {
                try
                {
                    string pathPart = createProductModel.CategoryId == 9 ? "shoes" : "clothes";
                    string path = Path.Combine(webHostEnvironment.WebRootPath, pathPart);

                    UploadProductImgModel uploadProductImgModel = new UploadProductImgModel()
                    {
                        ProductId = productId,
                        PictureFile = file,
                        ProductCategory = createProductModel.CategoryId == 9 ? "Shoes" : "clothes"
                    };

                    await pictureService.UploadImgAsync(uploadProductImgModel, path);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return Ok();
        }
        [HttpPost]
        [Route("SetFeature")]
        public async Task<IActionResult> SetFeature([FromBody] int productId)
        {
            if (!await productSevice.CheckIfProductExistsByIdAsync(productId))
            {
                return BadRequest();
            }
            await productSevice.SetProductToBeFeaturedByIdAsync(productId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("RemoveFeature")]
        public async Task<IActionResult> RemoveFeature([FromBody] int productId)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(productId))
            {
                return BadRequest();
            }
            await productSevice.RemoveProductFromBeFeaturedProductsByIdAsync(productId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
    }
}
