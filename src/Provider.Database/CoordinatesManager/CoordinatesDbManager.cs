using Domain.Coordinates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Provider.Database.Context;
using Provider.Database.Models;

namespace Provider.Database.CoordinatesManager;
public class CoordinatesDbManager : ICoordinatesDbManager
{
    private readonly DatabaseContext _context;

    public CoordinatesDbManager(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<CoordinatesEntity> GetCoords()
    {
        IEnumerable<CoordinatesEntity> coords = _context.Set<DbTrack>()
            .Include(x => x.FirstPoint)
            .Include(y => y.SecondPoint)
            .Select(x =>
                new CoordinatesEntity
                {
                    FirstId = x.FirstId,
                    SecondId = x.SecondId,
                    Surface = x.Surface,
                    MaxSpeed = x.MaxSpeed,
             });

        return coords;
    }

    public IEnumerable<AggregateCoordinatesEntity> GetAggrCoords()
    {
        IEnumerable<AggregateCoordinatesEntity> coords = _context.Set<DbAggregatesPoints>()
            .Include(x => x.Point)
            .Include(y => y.Track)
            .Select(coord => new AggregateCoordinatesEntity
            {
                Height = coord.Point.Height,
                Distance = coord.Track.Distance,
                MaxSpeed = coord.Track.MaxSpeed,
                Surface = coord.Track.Surface,
            });

        return coords;
    }
}
