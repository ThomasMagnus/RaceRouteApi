using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Provider.Database.Models;

namespace Provider.Database.Context.Configs;
internal class DbPointConfig : IEntityTypeConfiguration<DbPoint>
{
    public void Configure(EntityTypeBuilder<DbPoint> builder)
    {
        builder.ToTable("Points");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Height).IsRequired();

        builder.HasIndex(x => x.Id);

        builder.HasData(
            new DbPoint { Id = Guid.Parse("24a1084a-b81e-4285-802a-9241c8a8cd7d"), Height = 134.0, Name = "Point3" },
            new DbPoint { Id = Guid.Parse("41737d8b-3ff7-4b41-aac6-70c1e6c44897"), Height = 170.0, Name = "Point6" },
            new DbPoint { Id = Guid.Parse("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), Height = 124.0, Name = "Point5" },
            new DbPoint { Id = Guid.Parse("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), Height = 157.0, Name = "Point2" },
            new DbPoint { Id = Guid.Parse("dbf48ff1-831d-4421-b356-fb4a430809de"), Height = 145.0, Name = "Point1" },
            new DbPoint { Id = Guid.Parse("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), Height = 206.0, Name = "Point4" }
        );
    }
}
