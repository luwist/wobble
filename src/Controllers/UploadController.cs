using Microsoft.AspNetCore.Mvc;
using wobble.src.Requests;
using wobble.src.Services;

namespace wobble.src.Controllers
{
    [ApiController]
    [Route("upload")]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            this._uploadService = uploadService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadRequest request)
        {
            await this._uploadService.Upload(request);

            return Ok();
        }
    }
}