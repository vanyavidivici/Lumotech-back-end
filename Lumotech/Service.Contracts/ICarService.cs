﻿using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllCarsAsync(bool trackChanges);
    Task<CarDto> GetCarAsync(Guid id, bool trackChanges);
    Task<CarDto> CreateCarAsync(CarForCreationDto car);
    Task DeleteCarAsync(Guid id, bool trackChanges);
}