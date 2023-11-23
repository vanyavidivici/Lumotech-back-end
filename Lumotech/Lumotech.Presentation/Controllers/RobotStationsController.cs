using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/robotstations")]
[ApiController]
public class RobotStationsController : ControllerBase
{
    private readonly IServiceManager _service;
    
    public RobotStationsController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetRobotStations()
    {
        var robotStations = 
            await _service.RobotStationService.GetAllRobotStationsAsync(trackChanges: false);
        return Ok(robotStations);
    }
    
    [HttpGet("{id:guid}", Name = "RobotStationById")]
    public async Task<IActionResult> GetRobotStation(Guid id)
    {
        var robotStation = await _service.RobotStationService.GetRobotStationAsync(id, trackChanges: false);
        return Ok(robotStation);
    }
}