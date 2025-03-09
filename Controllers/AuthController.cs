using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IUserService userService, JwtService jwtService)
        {
            _authService = authService;
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var users = await _userService.GetUsersAsync();
            if(!await _userService.ValidateUserAsync(login.email, login.password))
            {
               return NotFound();
            }
            var user = await _userService.GetUserByEmailAsync(login.email);
            await _userService.ValidateUserRoleAsync(user);
            var token = _jwtService.GenerateToken(user);
            return Ok(user);
        }
        [HttpPost("/api/forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody]string email)
        {
            var result = await _authService.ForgotPasswordAsync(email);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut("/api/reset-password/{dto.Token}")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            var result = await _authService.ResetPasswordAsync(dto);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
