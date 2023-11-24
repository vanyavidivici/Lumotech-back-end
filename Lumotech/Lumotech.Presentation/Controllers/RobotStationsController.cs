using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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
    
    [HttpPost]
    public async Task<IActionResult> CreateRobotStation([FromBody] RobotStationForCreationDto robotStation)
    {
        if (robotStation is null)
            return BadRequest("RobotStationForCreationDto object is null");
        
        var createdRobotStation = await _service.RobotStationService.CreateRobotStationAsync(robotStation);
        
        return CreatedAtRoute("RobotStationById", new { id = createdRobotStation.Id },
            createdRobotStation);
    }
}