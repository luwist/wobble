using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wobble.src.Models;

namespace wobble.src.Response
{
    public class RegisterResponse
    {
        public User User { get; set; } = null!;
    }
}