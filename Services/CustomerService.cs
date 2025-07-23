using Microsoft.EntityFrameworkCore;
using CustomerOrderServiceAPI.Data;
using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Models;
using AutoMapper;

namespace CustomerOrderServiceAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<CustomerService> _logger;
        private readonly IMapper _mapper;
        private readonly ITenantProvider _tenantProvider;

        public CustomerService(AppDbContext db, ILogger<CustomerService> logger, IMapper mapper, ITenantProvider tenantProvider)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
            _tenantProvider = tenantProvider;
        }

        public async Task<Customer> RegisterAsync(RegisterDto dto)
        {
            try
            {
                if (await _db.Customers.AnyAsync(u => u.Email == dto.Email))
                    throw new Exception("Email already registered in this Tenant!");

                var customer = _mapper.Map<Customer>(dto);
                customer.TenantId = _tenantProvider.TenantId;

                _db.Customers.Add(customer);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Customer registered: {Email}", dto.Email);
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering customer with email {Email}", dto.Email);
                throw; 
            }
        }
    }
}