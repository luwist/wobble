using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using wobble.src.Exceptions;
using wobble.src.Requests;
using wobble.src.Response;
using wobble.src.Services;
using wobble.src.Validators;

namespace wobble.src.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                RegisterRequestValidator validator = new RegisterRequestValidator();
                ValidationResult result = validator.Validate(request);

                if (!result.IsValid) return BadRequest(result.Errors);

                RegisterResponse registerResponse = await this._authService.Register(request);
                
                return Ok(registerResponse);
            }
            catch (AlreadyExistsException)
            {
                return Conflict("User already exists");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                LoginRequestValidator validator = new LoginRequestValidator();
                ValidationResult result = validator.Validate(request);

                if (!result.IsValid) return BadRequest(result.Errors);

                LoginResponse loginResponse = await this._authService.Login(request);
                
                return Ok(loginResponse);
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}