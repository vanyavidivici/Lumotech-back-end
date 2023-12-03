﻿using Lumotech.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Lumotech.Presentation.Controllers;

[Route("api/robotstations/{robotStationId}/robots")]
[ApiController]
public class RobotsController : ControllerBase
{
    private readonly IServiceManager _service;

    public RobotsController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetRobotsForRobotStation(Guid robotStationId, 
        [FromQuery] RobotParameters robotParameters)
    {
        var robots = await _service.RobotService.GetRobotsAsync(robotStationId, robotParameters,
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
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateRobotForRobotStation(Guid robotStationId, 
        [FromBody] RobotForCreationDto robot)
    {
        var robotToReturn = await _service.RobotService.CreateRobotForRobotStationAsync(robotStationId, robot, 
            trackChanges: false);
        
        return CreatedAtRoute("GetRobotForRobotStation", new { robotStationId, 
                id = robotToReturn.Id }, robotToReturn);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRobotForRobotStation(Guid robotStationId, Guid id)
    {
        await _service.RobotService.DeleteRobotForRobotStationAsync(robotStationId, id, trackChanges: false);

        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateRobotForRobotStation(Guid robotStationId, Guid id,
        [FromBody] RobotForUpdateDto robot)
    {
        await _service.RobotService.UpdateRobotForRobotStationAsync(robotStationId, id, robot,
            robotStatTrackChanges: false, robotTrackChanges: true);

        return NoContent();
    }
}