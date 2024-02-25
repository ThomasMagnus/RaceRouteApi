using Asp.Versioning;
using Domain.Coordinates;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CoordinatesController : ControllerBase
{
    private readonly ICoordinatesDbManager _coordinatesDbManager;

    public CoordinatesController(ICoordinatesDbManager coordinatesDbManager)
    {
        _coordinatesDbManager = coordinatesDbManager;
    }

    [HttpGet("")]
    public IActionResult RetrieveCoordinates()
    {
        IEnumerable<CoordinatesEntity> entity = _coordinatesDbManager.GetCoords();
        IEnumerable<AggregateCoordinatesEntity> aggrCoords = _coordinatesDbManager.GetAggrCoords();

        return Ok(aggrCoords);
    }
}
