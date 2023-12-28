using Microsoft.EntityFrameworkCore;
using wobble.src.Models;

namespace wobble.src.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}