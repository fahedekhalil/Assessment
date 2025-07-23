using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderServiceAPI.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public string TenantId { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public List<CustomerOrderItem> Items { get; set; } = new List<CustomerOrderItem>();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}