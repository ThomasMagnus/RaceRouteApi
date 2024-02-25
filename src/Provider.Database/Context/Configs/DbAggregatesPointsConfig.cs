using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Provider.Database.Models;

namespace Provider.Database.Context.Configs;

internal class DbAggregatesPointsConfig : IEntityTypeConfiguration<DbAggregatesPoints>
{
    public void Configure(EntityTypeBuilder<DbAggregatesPoints> builder)
    {
        builder.ToTable("AggregatesPoints");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PointId).IsRequired();
        builder.Property(x => x.TrackId).IsRequired();

        builder.HasIndex(x => x.Id);

        builder
            .HasOne(x => x.Track)
            .WithMany()
            .HasForeignKey(x => x.TrackId);

        builder
            .HasOne(x => x.Point)
            .WithMany()
            .HasForeignKey(x => x.PointId);

        builder.HasData(
            new DbAggregatesPoints { PointId = new Guid("dbf48ff1-831d-4421-b356-fb4a430809de"), TrackId = new Guid("4c82ce6f-bd07-4f5d-9cdc-a8e3e44cea57") },
            new DbAggregatesPoints { PointId = new Guid("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), TrackId = new Guid("4c82ce6f-bd07-4f5d-9cdc-a8e3e44cea57") },
            new DbAggregatesPoints { PointId = new Guid("24a1084a-b81e-4285-802a-9241c8a8cd7d"), TrackId = new Guid("cfa042c8-6ecc-43d3-bc43-b962fe23b2ff") },
            new DbAggregatesPoints { PointId = new Guid("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), TrackId = new Guid("b5ee126c-cc87-4a57-ae34-d2859d300452") },
            new DbAggregatesPoints { PointId = new Guid("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), TrackId = new Guid("fbeb73bc-03fd-4fd6-9791-da5068791d1f") },
            new DbAggregatesPoints { PointId = new Guid("41737d8b-3ff7-4b41-aac6-70c1e6c44897"), TrackId = new Guid("d46960ad-70c4-418a-b366-64954356bdc1") }
        );
    }
}
