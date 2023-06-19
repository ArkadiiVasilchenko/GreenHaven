using IdentityService.Services.UserServices.UserServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetUser([FromRoute] string id)
        {
            var result = userService.ReadById(id);
            return Ok(result);
        }
    }
}
