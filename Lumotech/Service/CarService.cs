using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class CarService : ICarService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public CarService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}