using CustomerOrderServiceAPI.Models;
using CustomerOrderServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderServiceAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ITenantProvider _tenantProvider;
        public AppDbContext(DbContextOptions options, ITenantProvider tenantProvider) : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderItem> CustomerOrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<CustomerOrder>().HasQueryFilter(o => o.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<CustomerOrderItem>().HasQueryFilter(i => i.TenantId == _tenantProvider.TenantId);

            base.OnModelCreating(modelBuilder);
        }
    }
}