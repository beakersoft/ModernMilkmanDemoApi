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
        }
    }
}
