using System.ComponentModel.DataAnnotations;

namespace CustomerOrderServiceAPI.Models
{
    public class CustomerOrderItem
    {
        public int Id { get; set; }    
        public string TenantId { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}