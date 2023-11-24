using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Lumotech.Presentation.Controllers;

[Route("api/robotstations/{robotStationId}/robots")]
[ApiController]
public class RobotsController : ControllerBase
{
    private readonly IServiceManager _service;

    public RobotsController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetRobotsForRobotStation(Guid robotStationId)
    {
        var robots = await _service.RobotService.GetRobotsAsync(robotStationId, 
            trackChanges: false);
        return Ok(robots);
    }
    
    [HttpGet("{id:guid}", Name = "GetRobotForRobotStation")]
    public async Task<IActionResult> GetRobotForRobotStation(Guid robotStationId, Guid id)
    {
        var robot = await _service.RobotService.GetRobotAsync(robotStationId, id, trackChanges: false);
        return Ok(robot);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRobotForRobotStation(Guid robotStationId, 
        [FromBody] RobotForCreationDto robot)
    {
        if (robot is null)
            return BadRequest("RobotForCreationDto object is null");
        
        var robotToReturn = await _service.RobotService.CreateRobotForRobotStationAsync(robotStationId, robot, 
            trackChanges: false);
        
        return CreatedAtRoute("GetRobotForRobotStation", new { robotStationId, 
                id = robotToReturn.Id }, robotToReturn);
    }
}