using AuthenticationJWT.Domain.Interfaces;
using AuthenticationJWT.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationJWT.WebApi.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser([FromRoute] int userId)
        {
            _userService.GetUser(userId);
            return Ok(_userService.GetUser(userId));
        }
    }
}
