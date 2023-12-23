using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wobble.src.Request;
using wobble.src.Response;

namespace wobble.src.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}