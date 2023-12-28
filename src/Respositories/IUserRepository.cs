using wobble.src.Models;
using wobble.src.Requests;

namespace wobble.src.Respositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmail(string email);
        Task<User> Create(RegisterRequest request);
    }
}