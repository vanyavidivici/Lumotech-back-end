using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IRobotStationRepository
{
    Task<IEnumerable<RobotStation>> GetAllRobotStationsAsync(RobotStationParameters robotStationParameters, 
        bool trackChanges);
    Task<RobotStation> GetRobotStationAsync(Guid robotStationId, bool trackChanges);
    void CreateRobotStation(RobotStation robotStation);
    void DeleteRobotStation(RobotStation robotStation);
}