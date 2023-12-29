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

        public async Task<bool> Upload(UploadRequest request)
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "src", "Uploads");

            string path = Path.Combine(directory, request.File.FileName);

            using (FileStream stream = File.Create(path))
            {
                await request.File.CopyToAsync(stream);
            }

            // await this._photoRepository.Create(request);

            return true;
        }
    }
}