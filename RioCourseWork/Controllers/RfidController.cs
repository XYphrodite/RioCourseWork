using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RfidController : ControllerBase
    {
        public RfidController(Repository repo)
        {
            Repo = repo;
        }

        public Repository Repo { get; }

        [HttpPost]
        public async Task<string> Check([FromForm] string str) => await Repo.CheckKey(str) ? "1" : "0";
    }
}
