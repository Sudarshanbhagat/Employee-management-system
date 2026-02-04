using Microsoft.AspNetCore.Mvc;
using EMS.Data.DTOs;
using EMS.Services.Interfaces;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var response = await _authenticationService.LoginAsync(request.Email, request.Password);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            await _authenticationService.RegisterAsync(request);
            return Ok(new { message = "User registered successfully" });
        }
    }
}
