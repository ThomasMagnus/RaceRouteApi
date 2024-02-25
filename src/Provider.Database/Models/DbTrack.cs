using Domain.Entities;

namespace Provider.Database.Models;

internal sealed class DbTrack
{
    internal Guid Id { get; set; } = Guid.NewGuid();
    internal Guid FirstId { get; set; }
    internal Guid SecondId { get; set; }
    internal double Distance { get; set; }
    internal Surface Surface { get; set; }
    internal MaxSpeed MaxSpeed { get; set; }

    public DbPoint FirstPoint { get; set; } = null!;
    public DbPoint SecondPoint { get; set; } = null!;
}   
