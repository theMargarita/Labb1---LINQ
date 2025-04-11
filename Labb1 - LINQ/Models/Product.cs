using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength (250)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        //Foreign keys
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }


        //Navigation property - Connections
        public Category Category { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails = new List<OrderDetail>();
    }
}
