using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class CarService : ICarService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CarService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CarDto> GetAllCars(bool trackChanges)
    {
        var cars = _repository.Car.GetAllCars(trackChanges);
            
        var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            
        return carsDto;
    }
}