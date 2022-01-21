using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => new
            {
                e.Id
            });

            builder
                .HasMany(d => d.Address)
                .WithOne(e => e.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
