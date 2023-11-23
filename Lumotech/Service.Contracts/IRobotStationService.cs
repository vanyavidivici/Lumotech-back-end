using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IRobotStationService
{
    Task<IEnumerable<RobotStationDto>> GetAllRobotStationsAsync(bool trackChanges);
    Task<RobotStationDto> GetRobotStationAsync(Guid id, bool trackChanges);
    Task<RobotStationDto> CreateRobotStation(RobotStationForCreationDto robotStation);
}