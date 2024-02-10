namespace EcommerceApp.Controllers.Admin
{
    using EcommerceApp.Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.GeneralApplicationConstants;

    [Route("api/shoes")]
    [Authorize(Roles = AdminRoleName)]
    [ApiController]
    [Produces("application/json")]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService shoesService;
        public ShoesController(IShoesService shoesService)
        {
            this.shoesService = shoesService;
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
    }
}
