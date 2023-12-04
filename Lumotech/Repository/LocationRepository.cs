using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class LocationRepository : RepositoryBase<Location>, ILocationRepository
{
    public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync(LocationParameters locationParameters, 
        bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Country)
            .Skip((locationParameters.PageNumber - 1) * locationParameters.PageSize)
            .Take(locationParameters.PageSize)
            .ToListAsync();
    
    public async Task<Location> GetLocationAsync(Guid locationId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(locationId), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateLocation(Location location) => Create(location);

    public void DeleteLocation(Location location) => Delete(location);
}