namespace EcommerceApp.Controllers.Admin
{
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.AdminModels.Clothes;
    using EcommerceApp.SignalR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using static Common.GeneralApplicationConstants;

    [Route("api/shoes")]
    [Authorize(Roles = AdminRoleName)]
    [ApiController]
    [Produces("application/json")]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService shoesService;
        private readonly IHubContext<NotificationsHub> hubContext;
        public ShoesController(IShoesService shoesService, IHubContext<NotificationsHub> hubContext)
        {
            this.shoesService = shoesService;
            this.hubContext = hubContext;
        }

        [HttpGet]
        [Route("LoadAllShoes")]
        public async Task<IActionResult> LoadAllShoes()
        {
            var shoes = await shoesService.GetAllShoesAsync();

            return Ok(shoes);
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
    }
}
