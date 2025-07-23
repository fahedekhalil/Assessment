using Microsoft.AspNetCore.Mvc;
using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Services;

namespace CustomerOrderServiceAPI.Controllers
{
    [ApiController]
    [Route("api/{tenantId}/orders")]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly ICustomerOrderService _service;
        public CustomerOrdersController(ICustomerOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            try
            {
                var order = await _service.CreateOrderAsync(dto);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            try
            {
                var orders = await _service.GetOrdersAsync(customerId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}