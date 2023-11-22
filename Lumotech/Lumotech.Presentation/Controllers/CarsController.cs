﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Lumotech.Presentation.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IServiceManager _service;
    
    public CarsController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public IActionResult GetCars()
    {
        var cars = _service.CarService.GetAllCars(trackChanges: false);
        return Ok(cars);
    }
}