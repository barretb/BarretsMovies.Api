using BarretsMovies.Api.Models;
using BarretsMovies.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarretsMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private IDataService _dataService;

        public GenresController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("/movies")]
        public List<Genre> GetMovies(int? page, int? limit)
        {
            return _dataService.Genres
                .Skip((page ?? 0) * (limit??25))
                .Take(limit??25)
                .ToList();
        }

    }
}
