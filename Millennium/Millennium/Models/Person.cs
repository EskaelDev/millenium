using System.ComponentModel.DataAnnotations;

namespace Millennium.Models
{
    public class Person : BaseEntity
    {
        [Required]
        public string? Name { get; set; }        
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int Age { get; set; }
    }
}
