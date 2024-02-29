using AppSettings.BasicWebAPI.Application.Services.Interfaces;
using AppSettings.BasicWebAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppSettings.BasicWebAPI.Application.Controllers {     //https://ravindradevrani.medium.com/net-7-jwt-authentication-and-role-based-authorization-5e5e56979b67
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger) {
            _authService = authService;
            _logger = logger;            
        }

        [HttpPost]
        [Route("logins")]
        public async Task<IActionResult> Login(LoginModel model) {
            try {
                if(!ModelState.IsValid) {
                    return BadRequest("Invalid payload!");
                }
                var(status, message) = await _authService.Login(model);
                if (status == 0) {
                    return BadRequest(message);
                }
                return Ok(message);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegistrationModel model) {    // http: 201 - Created
            try {
                if(!ModelState.IsValid) {
                    return BadRequest("Invalid payload!");
                }
                //var (status, message) = await _authService.Registration(model , UserRole.User);
                var (status, message) = await _authService.Registration(model , UserRole.Admin);
                if (status == 0) {
                    return BadRequest(message);
                }
                //return Ok(message);
                return CreatedAtAction(nameof(Register), model);
            }
            catch(Exception ex) {
                _logger.LogError (ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError , ex.Message);
            }
        }
    }
}
