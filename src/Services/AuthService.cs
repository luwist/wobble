using wobble.src.Exceptions;
using wobble.src.Managers;
using wobble.src.Models;
using wobble.src.Requests;
using wobble.src.Response;
using wobble.src.Respositories;

namespace wobble.src.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManager _tokenManager;

        public AuthService(IUserRepository userRepository, ITokenManager tokenManager)
        {
            this._userRepository = userRepository;
            this._tokenManager = tokenManager;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            User? user = await this._userRepository.GetByEmail(request.Email);

            if (user is not null) throw new AlreadyExistsException();

            User userCreated = await this._userRepository.Create(request);

            return new RegisterResponse
            {
                User = userCreated
            };
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            User? user = await this._userRepository.GetByEmail(request.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new InvalidCredentialsException();

            return new LoginResponse
            {
                Token = this._tokenManager.CreateToken(user)
            };
        }
    }
}