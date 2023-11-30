using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LocationRepository : RepositoryBase<Location>, ILocationRepository
{
    public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Country)
            .ToListAsync();
    
    public async Task<Location> GetLocationAsync(Guid locationId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(locationId), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateLocation(Location location) => Create(location);

    public void DeleteLocation(Location location) => Delete(location);
}