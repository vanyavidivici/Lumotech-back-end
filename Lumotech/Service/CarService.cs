using Contracts;
using Entities.Models;
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

    public IEnumerable<Car> GetAllCars(bool trackChanges)
    {
        try
        {
            var cars = _repository.Car.GetAllCars(trackChanges);
            
            return cars;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCars)} service method {ex}");
            throw;
        }
    }
}