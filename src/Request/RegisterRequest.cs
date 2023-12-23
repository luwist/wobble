using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wobble.src.Request
{
    public class RegisterRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}