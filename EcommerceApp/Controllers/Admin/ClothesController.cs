namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Core.Contracts;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.AdminModels.ProductStock;
    using static Common.GeneralApplicationConstants;
    using SignalR;
    using Core.Models.AdminModels.Promotion;

    [ApiController]
    [Authorize(Roles = AdminRoleName)]
    [Produces("application/json")]
    [Route("api/clothes")]
    public class ClothesController : ControllerBase
    {
        private readonly IProductSevice productSevice;
        private readonly IProductStockService productStockService;
        private readonly IHubContext<NotificationsHub> hubContext;

        public ClothesController(IProductSevice productSevice, IProductStockService productStockService, 
            IHubContext<NotificationsHub> hubContext)
        {
            this.productSevice = productSevice;
            this.productStockService = productStockService;
            this.hubContext = hubContext;
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
        [Route("AddPromotion")]
        public async Task<IActionResult> AddPromotion([FromBody] AddPromotionModel addPromotionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await productSevice.ApplyPromotionAsync(addPromotionModel);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("Archive")]
        public async Task<IActionResult> Archive([FromBody] int productId)
        {
            if (!await productSevice.CheckIfProductExistsByIdAsync(productId))
            {
                return BadRequest();
            }
            await productSevice.ArchiveProductAsync(productId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("Restore")]
        public async Task<IActionResult> Restore([FromBody] int productId)
        {
            if (!await productSevice.CheckIfProductExistsByIdAsync(productId))
            {
                return BadRequest();
            }
            await productSevice.RestoreProductAsync(productId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
       
    }
}
