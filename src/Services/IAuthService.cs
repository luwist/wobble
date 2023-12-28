using wobble.src.Requests;
using wobble.src.Response;

namespace wobble.src.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}