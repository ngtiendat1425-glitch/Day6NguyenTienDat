using System.ComponentModel.DataAnnotations;

namespace Day6NguyenTienDat.Models
{
    public class Movice
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Duration { get; set; }
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}
