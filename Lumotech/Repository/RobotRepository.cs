using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class RobotRepository : RepositoryBase<Robot>, IRobotRepository
{
    public RobotRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Robot>> GetRobotsAsync(Guid robotStationId, RobotParameters robotParameters, 
        bool trackChanges) => 
        await FindByCondition(e => e.RobotStationId.Equals(robotStationId), trackChanges)
            .Search(robotParameters.SearchTerm)
            .Sort(robotParameters.OrderBy)
            .Skip((robotParameters.PageNumber - 1) * robotParameters.PageSize)
            .Take(robotParameters.PageSize)
            .ToListAsync();

    public async Task<Robot> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges) => 
        await FindByCondition(e => e.RobotStationId.Equals(robotStationId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateRobotForRobotStation(Guid robotStationId, Robot robot)
    {
        robot.RobotStationId = robotStationId;
        Create(robot);
    }

    public void DeleteRobot(Robot robot) => Delete(robot);
}