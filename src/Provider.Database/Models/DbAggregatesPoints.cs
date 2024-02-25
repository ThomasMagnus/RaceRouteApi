namespace Provider.Database.Models;

internal class DbAggregatesPoints
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PointId { get; set; }
    public Guid TrackId { get; set; }

    public DbPoint Point { get; set; } = null!;
    public DbTrack Track { get; set; } = null!;
}
