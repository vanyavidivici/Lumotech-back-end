﻿using Lumotech.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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
}