using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class RobotStationService : IRobotStationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public RobotStationService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}