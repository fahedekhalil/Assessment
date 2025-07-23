using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Models;

namespace CustomerOrderServiceAPI.Services
{
    public interface ICustomerOrderService
    {
        Task<CustomerOrder> CreateOrderAsync(CreateOrderDto dto);
        Task<List<CustomerOrder>> GetOrdersAsync(int customerId);
    }
}