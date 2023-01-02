using Microsoft.AspNetCore.Mvc;

namespace DemoTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GeJwtToken")]
        public IActionResult Jwt()
        {
            var key = _configuration["SECRET_KEY"];
            return new ObjectResult( JwtTokenFixer.GenerateJwtToken(key ?? "") );
        }
    }
}
