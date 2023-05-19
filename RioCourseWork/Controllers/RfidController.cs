using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RioCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RfidController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> Check(string str)
        {
            return true;
        }
    }
}
