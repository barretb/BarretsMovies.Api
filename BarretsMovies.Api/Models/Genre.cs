using System.ComponentModel.DataAnnotations;

namespace BarretsMovies.Api.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int TotalMovies { get; set; }
        public List<Guid> Movies { get; set; }
    }
}
