using Microsoft.AspNetCore.Mvc;
using OAuthAuthenticationAPI.Services;
using OAuthAuthenticationAPI.Helpers;
using OAuthAuthenticationAPI.Models;

namespace OAuthAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly UserServices _userService;
        private readonly string _secret;

        public UserLoginController(UserServices userService, IConfiguration configuration)
        {
            _userService = userService;
            _secret = configuration.GetValue<string>("JwtSecret");
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login loginModel)
        {
            var user = _userService.Authenticate(loginModel.Username, loginModel.Password);

            if (user == null)
                return Unauthorized();

            var token = JwtTokenGenerator.GenerateToken(user, _secret);
            return Ok(new { token });
        }

    }
}
