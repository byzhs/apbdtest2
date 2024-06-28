using System.ComponentModel.DataAnnotations;

namespace APBDTEST2.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}