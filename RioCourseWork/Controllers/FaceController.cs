using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RioCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        [HttpPost]
        public string Check([FromForm] IFormFile imageFile)
        {
            return "Test";
        }
    }
}
