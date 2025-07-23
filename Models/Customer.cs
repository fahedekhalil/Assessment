using System.ComponentModel.DataAnnotations;

namespace CustomerOrderServiceAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }       
        public string TenantId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}