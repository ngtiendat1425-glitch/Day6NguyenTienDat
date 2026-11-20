using System.ComponentModel.DataAnnotations;

namespace Day6NguyenTienDat.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        // Một thể loại có nhiều phim
        public ICollection<Movice> Movies { get; set; }
            = new List<Movice>();
    }
}
