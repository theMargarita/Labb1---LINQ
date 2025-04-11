using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public int Phone { get; set; }

        //Navigation Property
        public ICollection<Category> Categorys = new List<Category>();
    }
}