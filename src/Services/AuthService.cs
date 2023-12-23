using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using wobble.src.Exceptions;
using wobble.src.Models;
using wobble.src.Request;
using wobble.src.Response;
using wobble.src.Respositories;

namespace wobble.src.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            User? user = await this._userRepository.GetByEmail(request.Email);

            if (user is not null) throw new AlreadyExistsException();

            await this._userRepository.Create(request);

            return new RegisterResponse();
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            User? user = await this._userRepository.GetByEmail(request.Email);

            if (user is null) throw new NotFoundException();

            if (!BCrypt.Verify(request.Password, user.Password)) throw new InvalidCredentialsException();

            return new LoginResponse();
        }
    }
}