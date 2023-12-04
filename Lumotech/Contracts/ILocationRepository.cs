using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllLocationsAsync(LocationParameters locationParameters, bool trackChanges);
    Task<Location> GetLocationAsync(Guid locationId, bool trackChanges);
    void CreateLocation(Location location);
    void DeleteLocation(Location location);
}