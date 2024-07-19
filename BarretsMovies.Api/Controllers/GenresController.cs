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

        [HttpGet("movies")]
        public List<Genre> GetMovies(int? page, int? limit)
        {
            var pageCount = 0;
            if(page != 0) pageCount = page.Value - 1;

            return _dataService.Genres
                .OrderBy(x => x.Title)
                .Skip(pageCount * (limit??25))
                .Take(limit??25)
                .ToList();
        }

    }
}
