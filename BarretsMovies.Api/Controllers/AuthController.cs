using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarretsMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpGet("/token")]
        public Guid Get()
        {
            return Guid.NewGuid();
        }
    }
}
