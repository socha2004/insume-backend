using insume_backend.Application.DTOs.Auth;
using insume_backend.Application.Interfaces;
using insume_backend.Application.DTOs.Auth;
using insume_backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace insume_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
        {
            try
            {
                var response = await _authService.RegisterAsync(dto);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);

            if (response == null)
                return Unauthorized(new { mensagem = "E-mail ou senha inválidos." });

            return Ok(response);
        }
    }
}