using wobble.src.Exceptions;

namespace wobble.src.Services
{
    public class PhotoService : IPhotoService
    {
        public FileStream Get(string filename)
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "src", "Uploads");
            string path = Path.Combine(directory, filename);

            if (!System.IO.File.Exists(path)) throw new NotFoundException();

            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }
    }
}