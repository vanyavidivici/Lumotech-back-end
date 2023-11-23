using Entities.Models;

namespace Contracts;

public interface IRobotStationRepository
{
    Task<IEnumerable<RobotStation>> GetAllRobotStationsAsync(bool trackChanges);
    Task<RobotStation> GetRobotStationAsync(Guid robotStationId, bool trackChanges);
    void CreateRobotStation(RobotStation robotStation);
}