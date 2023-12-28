namespace wobble.src.Requests
{
    public class UploadRequest
    {
        public string Title { get; set; } = null!;
        public IFormFile File { get; set; } = null!;
    }
}