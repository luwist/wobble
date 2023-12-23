using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using wobble.src.Context;
using wobble.src.Models;
using wobble.src.Request;

namespace wobble.src.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this._dbContext = applicationDbContext;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await this._dbContext.Users.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<bool> Create(RegisterRequest request)
        {
            User? user = await this._dbContext.Users.FirstOrDefaultAsync(p => p.Email == request.Email);

            if (user is null)
            {
                User userToCreate = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    Email = request.Email,
                    Password = BCrypt.HashPassword(request.Password),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                };

                await this._dbContext.Users.AddAsync(userToCreate);
                await this._dbContext.SaveChangesAsync();
            
                return true;
            }

            return false;
        }
    }
}