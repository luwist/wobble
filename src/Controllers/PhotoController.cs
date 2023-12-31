using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wobble.src.Exceptions;
using wobble.src.Services;

namespace wobble.src.Controllers
{
    [Authorize]
    [ApiController]
    [Route("photos")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            this._photoService = photoService;
        }

        [HttpGet("{filename}")]
        public IActionResult Get(string filename)
        {
            try
            {
                FileStream fileStream = this._photoService.Get(filename);

                return File(fileStream, "image/jpeg");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}