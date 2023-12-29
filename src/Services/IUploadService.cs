using wobble.src.Models;
using wobble.src.Requests;

namespace wobble.src.Services
{
    public interface IUploadService
    {
        Task<Photo> Upload(UploadRequest request);
    }
}