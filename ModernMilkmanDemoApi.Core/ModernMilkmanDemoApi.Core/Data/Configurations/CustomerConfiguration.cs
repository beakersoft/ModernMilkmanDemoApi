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

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Forename)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(e => e.MobileNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Active)
                .IsRequired();

            builder
                .HasMany(d => d.Address)
                .WithOne(e => e.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
