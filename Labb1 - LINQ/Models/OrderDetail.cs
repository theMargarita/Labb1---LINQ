using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class OrderDetail
    {
        //Annotations
        [Key]
        public int OrderDetailId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        //Foreign keys
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        //Navigation Property
        //Object of Class with the foreign key - a connection 
        public Product Product { get; set; } = null!;
        public Order Order { get; set; } = null!;

    }
}