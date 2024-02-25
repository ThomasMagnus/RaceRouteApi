using Domain.Entities;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Provider.Database.Models;

namespace Provider.Database.Context.Configs;
internal class DbTrackConfig : IEntityTypeConfiguration<DbTrack>
{
    public void Configure(EntityTypeBuilder<DbTrack> builder)
    {
        builder.ToTable("Tracks");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.FirstId).IsRequired();
        builder.Property(x => x.SecondId).IsRequired();
        builder.Property(x => x.Distance).IsRequired();
        builder.Property(x => x.Surface).IsRequired();
        builder.Property(x => x.MaxSpeed).IsRequired();
        builder.Property(x => x.Surface)
            .HasConversion<string>();
        builder.Property(x => x.MaxSpeed)
            .HasConversion<string>();

        builder.HasIndex(x => new { x.FirstId, x.SecondId });

        builder
            .HasOne(x => x.FirstPoint)
            .WithMany()
            .HasForeignKey(x => x.FirstId);

        builder
            .HasOne(x => x.SecondPoint)
            .WithMany()
            .HasForeignKey(x => x.SecondId);

        builder.HasData(
            new DbTrack { Id = Guid.Parse("0fd3b73e-7259-43b5-a971-2835767dbae4"), Distance = 0, FirstId = Guid.Parse("dbf48ff1-831d-4421-b356-fb4a430809de"), MaxSpeed = MaxSpeed.SLOW, SecondId = Guid.Parse("dbf48ff1-831d-4421-b356-fb4a430809de"), Surface = Surface.SAND },
            new DbTrack { Id = Guid.Parse("4c82ce6f-bd07-4f5d-9cdc-a8e3e44cea57"), Distance = 2314, FirstId = Guid.Parse("dbf48ff1-831d-4421-b356-fb4a430809de"), MaxSpeed = MaxSpeed.SLOW, SecondId = Guid.Parse("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), Surface = Surface.SAND },
            new DbTrack { Id = Guid.Parse("b5ee126c-cc87-4a57-ae34-d2859d300452"), Distance = 3472, FirstId = Guid.Parse("24a1084a-b81e-4285-802a-9241c8a8cd7d"), MaxSpeed = MaxSpeed.FAST, SecondId = Guid.Parse("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), Surface = Surface.ASPHALT },
            new DbTrack { Id = Guid.Parse("cfa042c8-6ecc-43d3-bc43-b962fe23b2ff"), Distance = 4598, FirstId = Guid.Parse("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), MaxSpeed = MaxSpeed.SLOW, SecondId = Guid.Parse("24a1084a-b81e-4285-802a-9241c8a8cd7d"), Surface = Surface.SAND },
            new DbTrack { Id = Guid.Parse("d46960ad-70c4-418a-b366-64954356bdc1"), Distance = 5927, FirstId = Guid.Parse("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), MaxSpeed = MaxSpeed.FAST, SecondId = Guid.Parse("41737d8b-3ff7-4b41-aac6-70c1e6c44897"), Surface = Surface.ASPHALT },
            new DbTrack { Id = Guid.Parse("fbeb73bc-03fd-4fd6-9791-da5068791d1f"), Distance = 6672, FirstId = Guid.Parse("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), MaxSpeed = MaxSpeed.NORMAL, SecondId = Guid.Parse("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), Surface = Surface.GROUND }
        );
    }
}
