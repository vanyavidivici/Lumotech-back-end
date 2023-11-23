using Entities.Models;

namespace Contracts;

public interface IRobotRepository
{
    Task<IEnumerable<Robot>> GetRobotsAsync(Guid robotStationId, bool trackChanges);
    Task<Robot> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges);
}