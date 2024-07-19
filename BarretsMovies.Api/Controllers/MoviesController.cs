using BarretsMovies.Api.Models;
using BarretsMovies.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarretsMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IDataService _dataService;

        public MoviesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public MovieResult Get(int? page, int? limit, string? search, string? genre, string? writer, string? director, string? actor, string? rating)
        {
            var resultcount = _dataService.Movies
                .Where(x => string.IsNullOrEmpty(search) || x.Title.Contains(search))
                .Where(x => string.IsNullOrEmpty(genre) || x.Genres.Contains(genre))
                .Where(x => string.IsNullOrEmpty(writer) || x.Writers.Contains(writer))
                .Where(x => string.IsNullOrEmpty(director) || x.Directors.Contains(director))
                .Where(x => string.IsNullOrEmpty(actor) || x.MainActors.Contains(actor))
                .Where(x => string.IsNullOrEmpty(rating) || (x.Rating != null && x.Rating.Equals(rating)))
                .Count();

            var subset = _dataService.Movies
                .Where(x => string.IsNullOrEmpty(search) || x.Title.Contains(search))
                .Where(x => string.IsNullOrEmpty(genre) || x.Genres.Contains(genre))
                .Where(x => string.IsNullOrEmpty(writer) || x.Writers.Contains(writer))
                .Where(x => string.IsNullOrEmpty(director) || x.Directors.Contains(director))
                .Where(x => string.IsNullOrEmpty(actor) || x.MainActors.Contains(actor))
                .Where(x => string.IsNullOrEmpty(rating) || (x.Rating != null && x.Rating.Equals(rating)))
                .Skip((page ?? 0) * (limit ?? 25))
                .Take(limit ?? 25);

            return new MovieResult()
            {
                Movies = subset.ToList(),
                TotalPages = (resultcount / (limit ?? 25)) + 1,
                TotalResults = resultcount
            };
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public Movie? Get(Guid id)
        {
            return _dataService.Movies.FirstOrDefault(x => x.Id.Equals(id));
        }
        [HttpGet("/titles")]
        public List<Movie> GetIdsAndTitles(int? page, int? limit)
        {
            return _dataService.Movies
                 .Skip((page ?? 0) * (limit ?? 25))
                 .Take(limit ?? 25)
                 .Select(x => new Movie()
                 {
                     Id = x.Id,
                     Title = x.Title
                 })
                 .ToList();
        }

        [HttpGet("/genres/{id}")]
        public Movie GetGenresDetails(Guid id)
        {
            return _dataService.Movies.FirstOrDefault(x => x.Id.Equals(id));
        }

        [HttpGet("/ratings")]
        public List<string> GetRatings()
        {
            return _dataService.Movies
                .Select(x => x.Rating)
                .Distinct()
                .ToList();
        }
    }
}
