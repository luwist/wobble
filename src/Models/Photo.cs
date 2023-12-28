namespace wobble.src.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public string Path { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}