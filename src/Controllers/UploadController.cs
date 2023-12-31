using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wobble.src.Models;
using wobble.src.Requests;
using wobble.src.Services;

namespace wobble.src.Controllers
{
    [Authorize]
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
            Photo photo = await this._uploadService.Upload(request);

            return Ok(photo);
        }
    }
}