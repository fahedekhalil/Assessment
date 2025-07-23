using AutoMapper;
using CustomerOrderServiceAPI.Data;
using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderServiceAPI.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<CustomerOrderService> _logger;
        private readonly IMapper _mapper;
        private readonly ITenantProvider _tenantProvider;


        public CustomerOrderService(AppDbContext db, ILogger<CustomerOrderService> logger, IMapper mapper, ITenantProvider tenantProvider)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
            _tenantProvider = tenantProvider;
        }

        public async Task<CustomerOrder> CreateOrderAsync(CreateOrderDto dto)
        {
            try
            {
                var order = _mapper.Map<CustomerOrder>(dto);
                order.TenantId = _tenantProvider.TenantId;

                foreach (var item in order.Items)
                {
                    item.TenantId = _tenantProvider.TenantId;
                }

                _db.CustomerOrders.Add(order);
                await _db.SaveChangesAsync();
                _logger.LogInformation("CustomerOrder created for customer {CustomerId}", dto.CustomerId);
                return order;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating order for customer {CustomerId}", dto.CustomerId);
                throw;
            }
        }

        public async Task<List<CustomerOrder>> GetOrdersAsync(int customerId)
        {
            try
            {
                return await _db.CustomerOrders
                    .Include(o => o.Items)
                    .Where(o => o.CustomerId == customerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for customer {CustomerId}", customerId);
                throw;
            }
        }
    }
}