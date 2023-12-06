﻿using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllCarsAsync(CarParameters carParameters, bool trackChanges);
    Task<IEnumerable<CarDto>> GetAllCarsForUserAsync(string userId, CarParameters carParameters, bool trackChanges);
    Task<CarDto> GetCarAsync(Guid id, bool trackChanges);
    Task<CarDto> CreateCarAsync(string userId, CarForCreationDto car);
    Task DeleteCarAsync(Guid id, bool trackChanges);
    Task UpdateCarAsync(Guid carId, CarForUpdateDto carForUpdate, bool trackChanges);
}