namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.AspNetCore.Hosting;
    using Core.Contracts;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.AdminModels.ProductStock;
    using static Common.GeneralApplicationConstants;
    using SignalR;
    using Core.Models.AdminModels.Promotion;
    using EcommerceApp.Infrastructure.Data.Models;

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

        public ClothesController(IProductSevice productSevice, IProductStockService productStockService,
            IHubContext<NotificationsHub> hubContext, IShoesService shoesService)
        {
            this.productSevice = productSevice;
            this.productStockService = productStockService;
            this.hubContext = hubContext;
            this.shoesService = shoesService;
        }

        [HttpGet]
        [Route("LoadAllClothes")]
        public async Task<IActionResult> LoadAllClothes()
        {
            var allClothes = await productSevice.LoadAllClothesAsync();
            return Ok(allClothes);
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
    }
}
