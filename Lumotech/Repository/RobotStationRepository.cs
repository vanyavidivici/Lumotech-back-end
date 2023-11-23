using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RobotStationRepository : RepositoryBase<RobotStation>, IRobotStationRepository
{
    public RobotStationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<RobotStation>> GetAllRobotStationsAsync(bool trackChanges) => 
        await FindAll(trackChanges)
            .OrderBy(c => c.LocationId)
            .ToListAsync();

    public async Task<RobotStation> GetRobotStationAsync(Guid robotStationId, bool trackChanges) => 
        await FindByCondition(c => c.Id.Equals(robotStationId), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateRobotStation(RobotStation robotStation) => Create(robotStation);
}