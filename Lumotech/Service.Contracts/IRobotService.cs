using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IRobotService
{
    Task<IEnumerable<RobotDto>> GetRobotsAsync(Guid robotStationId, bool trackChanges);
    Task<RobotDto> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges);
}