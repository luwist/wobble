using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wobble.src.Exceptions;
using wobble.src.Request;
using wobble.src.Response;
using wobble.src.Services;

namespace wobble.src.Controllers
{
    [ApiController]
    [Route("api/auth")]
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
                RegisterResponse registerResponse = await this._authService.Register(request);
                
                return Created();
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