using Microsoft.EntityFrameworkCore;
using ModernMilkmanDemoApi.Core.Data.Configurations;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Data
{
    public class DemoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
