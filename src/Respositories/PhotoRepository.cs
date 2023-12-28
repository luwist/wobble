using wobble.src.Context;
using wobble.src.Managers;
using wobble.src.Models;
using wobble.src.Requests;

namespace wobble.src.Respositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PhotoRepository(ApplicationDbContext applicationDbContext)
        {
            this._dbContext = applicationDbContext;
        }

        public async Task<Photo> Create(UploadRequest request)
        {
            PhotoManager photoManager = new PhotoManager(request.File);

            Photo photo = new Photo
            {
                Title = request.Title,
                Width = photoManager.Width,
                Height = photoManager.Height,
                Size = photoManager.Size,
                Path = $"Uploads/{request.File.FileName}",
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            await this._dbContext.Photos.AddAsync(photo);
            await this._dbContext.SaveChangesAsync();
        
            return photo;
        }
    }
}