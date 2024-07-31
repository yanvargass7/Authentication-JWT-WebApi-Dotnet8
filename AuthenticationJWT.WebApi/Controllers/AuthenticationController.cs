using AuthenticationJWT.Domain.Interfaces;
using AuthenticationJWT.Domain.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationJWT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IToken _tokenService;
        public AuthenticationController(IToken tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            return Ok(_tokenService.GenerateToken(login));
        }
    }
}
