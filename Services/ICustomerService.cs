using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Models;

namespace CustomerOrderServiceAPI.Services
{
    public interface ICustomerService
    {
        Task<Customer> RegisterAsync(RegisterDto dto);
    }
}