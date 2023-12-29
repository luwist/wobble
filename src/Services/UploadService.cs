using wobble.src.Models;
using wobble.src.Requests;
using wobble.src.Respositories;

namespace wobble.src.Services
{
    public class UploadService : IUploadService
    {
        private readonly IPhotoRepository _photoRepository;

        public UploadService(IPhotoRepository photoRepository)
        {
            this._photoRepository = photoRepository;
        }

        public async Task<Photo> Upload(UploadRequest request)
        {
            IFormFile file = request.File;

            string filename = request.File.FileName;
            string extension = Path.GetExtension(filename);
            string newFilename = $"{Guid.NewGuid()}{extension}";

            string path = Path.Combine(Directory.GetCurrentDirectory(), "src", "Uploads", newFilename);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }

            Photo photo = await this._photoRepository.Create(request, newFilename);

            return photo;
        }
    }
}