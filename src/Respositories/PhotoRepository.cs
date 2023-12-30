using System.Security.Claims;
using wobble.src.Context;
using wobble.src.Managers;
using wobble.src.Models;
using wobble.src.Requests;

namespace wobble.src.Respositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PhotoRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = applicationDbContext;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<Photo> Create(UploadRequest request, string filename)
        {
            string? userId = this._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PhotoManager photoManager = new PhotoManager(request.File, filename);

            Photo photo = new Photo
            {
                Title = request.Title,
                Width = photoManager.Width,
                Height = photoManager.Height,
                Size = photoManager.Size,
                Path = filename,
                CreatedAt = DateTime.Now,
                UpdatedAt = null,

                UserId = int.Parse(userId)
            };

            await this._dbContext.Photos.AddAsync(photo);
            await this._dbContext.SaveChangesAsync();
        
            return photo;
        }
    }
}