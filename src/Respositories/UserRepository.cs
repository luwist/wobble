using Microsoft.EntityFrameworkCore;
using wobble.src.Context;
using wobble.src.Models;
using wobble.src.Requests;

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

        public async Task<User> Create(RegisterRequest request)
        {
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            await this._dbContext.Users.AddAsync(user);
            await this._dbContext.SaveChangesAsync();
        
            return user;
        }
    }
}