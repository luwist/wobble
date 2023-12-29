using SixLabors.ImageSharp;

namespace wobble.src.Managers
{
    public class PhotoManager
    {
        private readonly IFormFile _photo;

        public int Width
        {
            get
            {
                return this.GetWidth();
            }
        }

        public int Height
        {
            get
            {
                return this.GetHeight();
            }
        }
        public long Size
        {
            get
            {
                return this.GetSize();
            }
        }

        public string Mime
        {
            get
            {
                return this.GetMime();
            }
        }

        public string Extension
        {
            get
            {
                return this.GetExtension();
            }
        }

        private string _path;

        public PhotoManager(IFormFile photo, string filename)
        {
            this._photo = photo;
            this._path = Path.Combine(Directory.GetCurrentDirectory(), "src", "Uploads", filename);
        }

        private int GetWidth()
        {
            int width;

            using (Image image = Image.Load(this._path))
            {
                width = image.Width;
            }

            return width;
        }

        private int GetHeight()
        {
            int height;

            using (Image image = Image.Load(this._path))
            {
                height = image.Height;
            }

            return height;
        }

        private long GetSize()
        {
            return this._photo.Length;
        }

        private string GetMime()
        {
            return "";
        }

        private string GetExtension()
        {
            string filename = this._photo.FileName;

            return Path.GetExtension(filename);
        }
    }
}