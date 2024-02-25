using Domain.Entities;

namespace Domain.Coordinates;

public interface ICoordinatesDbManager
{
    public IEnumerable<CoordinatesEntity> GetCoords();
    public IEnumerable<AggregateCoordinatesEntity> GetAggrCoords();
}

