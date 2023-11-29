using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IRobotStationService
{
    Task<IEnumerable<RobotStationDto>> GetAllRobotStationsAsync(bool trackChanges);
    Task<RobotStationDto> GetRobotStationAsync(Guid id, bool trackChanges);
    Task<RobotStationDto> CreateRobotStationAsync(RobotStationForCreationDto robotStation);
    Task DeleteRobotStationAsync(Guid id, bool trackChanges);
    Task UpdateRobotStationAsync(Guid robotStationId, RobotStationForUpdateDto robotStationForUpdate, bool trackChanges);
}