using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public  class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength (100)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }


        public ICollection<Product> Products = new List<Product>();
    }
}