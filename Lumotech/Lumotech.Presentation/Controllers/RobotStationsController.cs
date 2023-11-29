using Lumotech.Presentation.ActionFilters;
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
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateRobotStation([FromBody] RobotStationForCreationDto robotStation)
    {
        var createdRobotStation = await _service.RobotStationService.CreateRobotStationAsync(robotStation);
        
        return CreatedAtRoute("RobotStationById", new { id = createdRobotStation.Id },
            createdRobotStation);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRobotStation(Guid id)
    {
        await _service.RobotStationService.DeleteRobotStationAsync(id, trackChanges: false);
        
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateRobotStation(Guid id, [FromBody] RobotStationForUpdateDto robotStation)
    {
        await _service.RobotStationService.UpdateRobotStationAsync(id, robotStation, trackChanges: true);

        return NoContent();
    }
}