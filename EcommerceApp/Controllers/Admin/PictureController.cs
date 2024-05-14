namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.AdminModels.Pictures;
    using static Common.GeneralApplicationConstants;

    [Route("api/picture")]
    [Authorize(Roles = AdminRoleName)]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPictureService pictureService;
        public PictureController(IWebHostEnvironment webHostEnvironment,
           IPictureService pictureService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.pictureService = pictureService;
        }

        [HttpPost]
        [Route("UploadImg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadImg([FromForm] UploadProductImgModel uploadProductImgModel)
        {
            try
            {
                string pathPart = uploadProductImgModel.ProductCategory == "Shoes" ? "shoes" : "clothes";
                string path = Path.Combine(webHostEnvironment.WebRootPath, pathPart);

                await pictureService.UploadImgAsync(uploadProductImgModel, path);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteImg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImg([FromBody] DeletePictureModel deletePictureModel)
        {
            if (!await pictureService.CheckIfImgExistsAsync(deletePictureModel.Id))
            {
                return BadRequest();
            }

            string pathPart = deletePictureModel.PictureProductCategory == "Shoes" ? "shoes" : "clothes";
            string path = Path.Combine(webHostEnvironment.WebRootPath, pathPart);

            await pictureService.DeleteImgAsync(deletePictureModel, path);

            return Ok();
        }
    }
}
