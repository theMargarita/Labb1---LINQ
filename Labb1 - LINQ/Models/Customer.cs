using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email { get; set; }
        //[Address]
        public string? Adress { get; set; }
        public int Phone { get; set; }

        //Navigation Property
        public ICollection<Order> Orders = new List<Order>();

    }
}