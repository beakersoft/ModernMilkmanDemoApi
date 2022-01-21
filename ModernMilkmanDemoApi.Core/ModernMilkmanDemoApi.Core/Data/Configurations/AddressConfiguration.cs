using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernMilkmanDemoApi.Core.Domain;

namespace ModernMilkmanDemoApi.Core.Data.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => new
            {
                e.Id
            });

            builder.Property(e => e.AddressLine1)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(e => e.AddressLine2)
                .HasMaxLength(80);

            builder.Property(e => e.Town)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.County)
                .HasMaxLength(50);


            builder.Property(e => e.PostCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Country)
                .HasMaxLength(50);

        }
    }
}
