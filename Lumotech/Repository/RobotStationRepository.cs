using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class RobotStationRepository : RepositoryBase<RobotStation>, IRobotStationRepository
{
    public RobotStationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<RobotStation>> GetAllRobotStationsAsync(RobotStationParameters robotStationParameters, 
        bool trackChanges) => 
        await FindAll(trackChanges)
            .OrderBy(c => c.LocationId)
            .Skip((robotStationParameters.PageNumber - 1) * robotStationParameters.PageSize)
            .Take(robotStationParameters.PageSize)
            .ToListAsync();

    public async Task<RobotStation> GetRobotStationAsync(Guid robotStationId, bool trackChanges) => 
        await FindByCondition(c => c.Id.Equals(robotStationId), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateRobotStation(RobotStation robotStation) => Create(robotStation);
    public void DeleteRobotStation(RobotStation robotStation) => Delete(robotStation);
}