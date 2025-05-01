using Elasticsearch.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Elasticsearch.API.Configurations
{
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.HasKey(e => e.ShipperId);

            builder.Property(e => e.ShipperId).HasColumnName("ShipperID");

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}
