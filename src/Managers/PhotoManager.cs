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

        public PhotoManager(IFormFile photo)
        {
            this._photo = photo;
        }

        private int GetWidth()
        {
            return 0;
        }

        private int GetHeight()
        {
            return 0;
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
            return "";
        }
    }
}