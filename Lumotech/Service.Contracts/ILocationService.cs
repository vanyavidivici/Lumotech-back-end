using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllLocationsAsync(LocationParameters locationParameters, bool trackChanges);
    Task<LocationDto> GetLocationAsync(Guid id, bool trackChanges);
    Task<LocationDto> CreateLocationAsync(LocationForCreationDto location);
    Task DeleteLocationAsync(Guid id, bool trackChanges);
    Task UpdateLocationAsync(Guid locationId, LocationForUpdateDto locationForUpdate, bool trackChanges);
}