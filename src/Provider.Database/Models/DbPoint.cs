namespace Provider.Database.Models;
internal sealed class DbPoint
{
    internal Guid Id { get; set; }
    internal string Name { get; set; } = null!;
    internal double Height { get; set; }
}
