﻿using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllLocationsAsync(bool trackChanges);
    Task<LocationDto> GetLocationAsync(Guid id, bool trackChanges);
    Task<LocationDto> CreateLocationAsync(LocationForCreationDto location);
    Task DeleteLocationAsync(Guid id, bool trackChanges);
    Task UpdateLocationAsync(Guid locationId, LocationForUpdateDto locationForUpdate, bool trackChanges);
}