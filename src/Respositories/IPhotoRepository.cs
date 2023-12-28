using wobble.src.Models;
using wobble.src.Requests;

namespace wobble.src.Respositories
{
    public interface IPhotoRepository
    {
        Task<Photo> Create(UploadRequest request);
    }
}