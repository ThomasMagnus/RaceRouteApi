namespace Domain.Entities;

public class AggregateCoordinatesEntity
{
    public double Height { get; init; }
    public double Distance { get; init; }
    public Surface Surface { get; init; }
    public MaxSpeed MaxSpeed { get; init; }
}
