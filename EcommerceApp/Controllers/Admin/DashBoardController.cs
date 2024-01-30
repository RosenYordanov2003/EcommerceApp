namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static EcommerceApp.Common.GeneralApplicationConstants;

    [Authorize(Roles = AdminRoleName)]
    [Route("api/[dashboard]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
    }
}
