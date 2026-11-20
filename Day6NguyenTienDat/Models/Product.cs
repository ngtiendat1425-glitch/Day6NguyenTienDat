using System.ComponentModel.DataAnnotations;

namespace Day6NguyenTienDat.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength =3)]
        public string? Name { get; set; }
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
