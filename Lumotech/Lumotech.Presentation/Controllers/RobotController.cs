using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/robotstations/{robotStationId}/robots")]
[ApiController]
public class RobotController : ControllerBase
{
    private readonly IServiceManager _service;

    public RobotController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetRobotsForRobotStation(Guid robotStationId)
    {
        var robots = await _service.RobotService.GetRobotsAsync(robotStationId, 
            trackChanges: false);
        return Ok(robots);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRobotForRobotStation(Guid robotStationId, Guid id)
    {
        var robot = await _service.RobotService.GetRobotAsync(robotStationId, id, trackChanges: false);
        return Ok(robot);
    }
}