using System.ComponentModel.DataAnnotations;

namespace BarretsMovies.Api.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Rating { get; set; }
        public string Summary { get; set; }
        public string Duration { get; set; }
        public List<string> Directors { get; set; }
        public List<string> MainActors { get; set; }
        public string DatePublished { get; set; }
        public double? RatingValue { get; set; }
        public int? BestRating { get; set; }
        public int? WorstRating { get; set; }
        public List<string> Writers { get; set; }
        public List<string> Genres { get; set; }
        public int? UserRating { get; set; }
    }

    public class MovieResult
    {
        public List<Movie> Movies { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
