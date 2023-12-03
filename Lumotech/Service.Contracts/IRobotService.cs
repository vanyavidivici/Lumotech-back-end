using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IRobotService
{
    Task<IEnumerable<RobotDto>> GetRobotsAsync(Guid robotStationId, RobotParameters robotParameters, bool trackChanges);
    Task<RobotDto> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges);
    Task<RobotDto> CreateRobotForRobotStationAsync(Guid robotStationId, RobotForCreationDto robotForCreation, 
        bool trackChanges);
    Task DeleteRobotForRobotStationAsync(Guid robotStationId, Guid id, bool trackChanges);
    Task UpdateRobotForRobotStationAsync(Guid robotStationId, Guid id,
        RobotForUpdateDto robotForUpdate, bool robotStatTrackChanges, bool robotTrackChanges);
}