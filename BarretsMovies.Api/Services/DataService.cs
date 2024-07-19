using BarretsMovies.Api.Models;
using Newtonsoft.Json;

namespace BarretsMovies.Api.Services
{
    public interface IDataService 
    {
        List<Movie> Movies { get; set; }
        List<Genre> Genres { get; set; }
    }

    public class DataService:IDataService
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }

        public DataService()
        { 
            using (StreamReader r = new StreamReader("./SeedData/seedData.json"))
            {
                string json = r.ReadToEnd();
                Movies = JsonConvert.DeserializeObject<List<Movie>>(json);

                Genres = new List<Genre>();
                foreach (var movie in Movies)
                {
                    movie.Id = Guid.NewGuid();
                    foreach (var genre in movie.Genres)
                    {
                        if (!Genres.Any(g => g.Title == genre))
                        {
                            Genres.Add(new Genre { Title = genre, Id = Guid.NewGuid(), TotalMovies = 1, Movies = new List<Guid>() {movie.Id }  });
                        } else
                        {
                            var updateGenre = Genres.First(g => g.Title == genre);
                            updateGenre.TotalMovies++;
                            updateGenre.Movies.Add(movie.Id);
                        }}
                    }
            }
        }
    }
}
