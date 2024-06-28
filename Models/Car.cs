using System.ComponentModel.DataAnnotations;

namespace APBDTEST2.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(17)]
        public string VIN { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public int Seats { get; set; }
        public int PricePerDay { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        
        public Model Model { get; set; }
        public Color Color { get; set; }
        public ICollection<CarRental> CarRentals { get; set; } = new List<CarRental>();
    }
}