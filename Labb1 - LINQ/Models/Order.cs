using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int TotalAmount { get; set; }

        public Status? Status { get; set; }


        //Navigation property
        public Customer? Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
    public enum Status
    {
        Behandlas = 1, Skickad, Levererad
    }
}
