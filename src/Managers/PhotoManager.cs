namespace wobble.src.Managers
{
    public class PhotoManager
    {
        private readonly IFormFile _photo;

        public int Width { get; }
        public int Height { get; }
        public int Size { get; }

        public PhotoManager(IFormFile photo)
        {
            this._photo = photo;
        }
    }
}