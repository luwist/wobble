using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wobble.src.Models;
using wobble.src.Request;

namespace wobble.src.Respositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmail(string email);
        Task<bool> Create(RegisterRequest request);
    }
}