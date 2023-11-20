using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class RobotService : IRobotService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public RobotService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}