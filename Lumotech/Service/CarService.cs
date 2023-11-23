using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync(bool trackChanges)
    {
        var cars = await _repository.Car.GetAllCarsAsync(trackChanges);
            
        var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            
        return carsDto;
    }

    public async Task<CarDto> GetCarAsync(Guid id, bool trackChanges)
    {
        var car = await _repository.Car.GetCarAsync(id, trackChanges);
        if (car is null) 
            throw new CarNotFoundException(id);
        
        var carDto = _mapper.Map<CarDto>(car);
        
        return carDto;
    }

    public async Task<CarDto> CreateCar(CarForCreationDto car)
    {
        var carEntity = _mapper.Map<Car>(car);
        
        _repository.Car.CreateCar(carEntity);
        await _repository.SaveAsync();
        
        var carToReturn = _mapper.Map<CarDto>(carEntity);
        return carToReturn;
    }
}