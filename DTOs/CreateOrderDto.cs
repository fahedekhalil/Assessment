using System.ComponentModel.DataAnnotations;

namespace CustomerOrderServiceAPI.DTOs
{
    public class OrderItemDto
    {
        [Required(ErrorMessage = "Item Desciption is required!")]
        public string ItemDescription { get; set; }= string.Empty;
        [Required(ErrorMessage = "Order Quantity is required!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Item Price is required!")]
        public decimal Price { get; set; }
    }

    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Customer Id is required!")]
        public int CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}