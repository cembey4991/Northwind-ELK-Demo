using Elasticsearch.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Elasticsearch.API.Configurations
{
    public class CustomerDemographicsConfiguration : IEntityTypeConfiguration<CustomerDemographics>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographics> builder)
        {
            builder.HasKey(e => e.CustomerTypeId);

            builder.Property(e => e.CustomerTypeId)
                .HasColumnName("CustomerTypeID")
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.CustomerDesc).HasColumnType("ntext");
        }
    }
}
