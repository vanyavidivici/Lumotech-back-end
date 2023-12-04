using Lumotech.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Lumotech.Presentation.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IServiceManager _service;
    
    public CarsController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetCars([FromQuery] CarParameters carParameters)
    {
        var cars = await _service.CarService.GetAllCarsAsync(carParameters, trackChanges: false);
        return Ok(cars);
    }
    
    [HttpGet("{id:guid}", Name = "CarById")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        var car = await _service.CarService.GetCarAsync(id, trackChanges: false);
        return Ok(car);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCar([FromBody] CarForCreationDto car)
    {
        var createdCar = await _service.CarService.CreateCarAsync(car);
        
        return CreatedAtRoute("CarById", new { id = createdCar.Id },
            createdCar);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        await _service.CarService.DeleteCarAsync(id, trackChanges: false);
        
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCar(Guid id, [FromBody] CarForUpdateDto car)
    {
        await _service.CarService.UpdateCarAsync(id, car, trackChanges: true);

        return NoContent();
    }
}