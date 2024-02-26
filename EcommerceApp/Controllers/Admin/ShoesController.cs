namespace EcommerceApp.Controllers.Admin
{
    using SignalR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Core.Contracts;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.AdminModels.ProductStock;
    using Core.Models.Pager;
    using static Common.GeneralApplicationConstants;

    [Route("api/shoes")]
    [Authorize(Roles = AdminRoleName)]
    [ApiController]
    [Produces("application/json")]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService shoesService;
        private readonly IHubContext<NotificationsHub> hubContext;
        private readonly IProductStockService productStockService;
        public ShoesController(IShoesService shoesService, IHubContext<NotificationsHub> hubContext, 
            IProductStockService productStockService)
        {
            this.shoesService = shoesService;
            this.hubContext = hubContext;
            this.productStockService = productStockService;
        }

        [HttpGet]
        [Route("LoadAllShoes")]
        public async Task<IActionResult> LoadAllShoes([FromQuery] int pageNumber)
        {
            int shoesCount = await shoesService.GetAllShoesCountAsync();

            Pager pager = new Pager(shoesCount, pageNumber, DefaultPageSize);
            var shoes = await shoesService.GetAllShoesAsync(pager);


            return Ok(new {Shoes = shoes, PagerObject = pager});
        }
        [HttpGet]
        [Route("LoadShoesToEdit")]
        public async Task<IActionResult>LoadShoesToEdit([FromQuery]int shoesId)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(shoesId))
            {
                return BadRequest();
            }

            var shoes = await shoesService.GetShoesToModifyAsync(shoesId);

            return Ok(shoes);
        }
        [HttpPost]
        [Route("editShoes")]
        public async Task<IActionResult> EditShoes([FromBody] EditProductModel editProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await shoesService.CheckIfShoesExistsByIdAsync(editProductModel.Id))
            {
                return BadRequest();
            }
            await shoesService.EditShoesAsync(editProductModel);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("addStock")]
        public async Task<IActionResult> AddShoesStock([FromBody] AddProductStockModel addProductStockModel)
        {
            await productStockService.IncreaseProductStockQuantity(addProductStockModel);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("SetFeature")]
        public async Task<IActionResult> SetFeature([FromBody] int shoesId)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(shoesId))
            {
                return BadRequest();
            }
            await shoesService.SetFeatureShoesByIdAsync(shoesId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
        [HttpPost]
        [Route("RemoveFeature")]
        public async Task<IActionResult> RemoveFeature([FromBody] int shoesId)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(shoesId))
            {
                return BadRequest();
            }
            await shoesService.RemoveFeaturedShoesByIdAsync(shoesId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }
    }
}
