using Elasticsearch.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Elasticsearch.API.Configurations
{
    public class TerritoriesConfiguration : IEntityTypeConfiguration<Territories>
    {
        public void Configure(EntityTypeBuilder<Territories> builder)
        {
            builder.HasKey(e => e.TerritoryId);

            builder.Property(e => e.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasMaxLength(20);

            builder.Property(e => e.RegionId).HasColumnName("RegionID");

            builder.Property(e => e.TerritoryDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength();

            builder.HasOne(d => d.Region)
                .WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        }
    }
}
