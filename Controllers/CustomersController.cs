using Microsoft.AspNetCore.Mvc;
using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Services;

namespace CustomerOrderServiceAPI.Controllers
{
    [ApiController]
    [Route("api/{tenantId}/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var customer = await _service.RegisterAsync(dto);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}