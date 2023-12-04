using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IRobotStationService
{
    Task<IEnumerable<RobotStationDto>> GetAllRobotStationsAsync(RobotStationParameters robotStationParameters, 
        bool trackChanges);
    Task<RobotStationDto> GetRobotStationAsync(Guid id, bool trackChanges);
    Task<RobotStationDto> CreateRobotStationAsync(RobotStationForCreationDto robotStation);
    Task DeleteRobotStationAsync(Guid id, bool trackChanges);
    Task UpdateRobotStationAsync(Guid robotStationId, RobotStationForUpdateDto robotStationForUpdate, bool trackChanges);
}