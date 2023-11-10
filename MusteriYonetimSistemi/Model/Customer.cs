using System.ComponentModel.DataAnnotations;

namespace MusteriYonetimSistemi.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
    }
}
