namespace wobble.src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Photo> Photos { get; } = new List<Photo>();
    }
}