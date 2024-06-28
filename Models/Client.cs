using System.ComponentModel.DataAnnotations;

namespace APBDTEST2.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;
        
        public ICollection<CarRental> CarRentals { get; set; } = new List<CarRental>();
    }
}