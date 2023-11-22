using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IServiceManager _service;
    
    public CarsController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _service.CarService.GetAllCarsAsync(trackChanges: false);
        return Ok(cars);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        var car = await _service.CarService.GetCarAsync(id, trackChanges: false);
        return Ok(car);
    }
}