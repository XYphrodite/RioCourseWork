using Microsoft.AspNetCore.Mvc;

namespace RioCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FaceController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<string> CheckAsync([FromForm] IFormFile imageFile)
        {
            var path = Path.Combine(webHostEnvironment.WebRootPath, "Cam", "o.jpg");
            using (var memoryStream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(memoryStream);
            }
            return "Ok";
        }
    }
}
