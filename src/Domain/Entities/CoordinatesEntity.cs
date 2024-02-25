namespace Domain.Entities;

public class CoordinatesEntity
{
    public Guid FirstId { get; init; }
    public Guid SecondId { get; init; }
    public Surface Surface { get; init; }
    public MaxSpeed MaxSpeed { get; init; }
    public double FirstPointHeigth { get; init; }
    public double SecondPointHeigth { get; init; }
    public double Distance { get; init; }
}

public enum Surface
{
    SAND,
    ASPHALT,
    GROUND
}

public enum MaxSpeed
{
    FAST,
    NORMAL,
    SLOW
}
