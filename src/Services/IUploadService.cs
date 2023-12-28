using wobble.src.Requests;

namespace wobble.src.Services
{
    public interface IUploadService
    {
        Task<bool> Upload(UploadRequest request);
    }
}