using Entities.Models;

namespace Contracts;

public interface IRobotRepository
{
    Task<IEnumerable<Robot>> GetRobotsAsync(Guid robotStationId, bool trackChanges);
    Task<Robot> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges);
    void CreateRobotForRobotStation(Guid robotStationId, Robot robot);
    void DeleteRobot(Robot robot);
}