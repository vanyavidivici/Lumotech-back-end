using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RobotRepository : RepositoryBase<Robot>, IRobotRepository
{
    public RobotRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Robot>> GetRobotsAsync(Guid robotStationId, bool trackChanges) => 
        await FindByCondition(e => e.RobotStationId.Equals(robotStationId), trackChanges)
        .OrderBy(e => e.SerialNumber).ToListAsync();

    public async Task<Robot> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges) => 
        await FindByCondition(e => e.RobotStationId.Equals(robotStationId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
}