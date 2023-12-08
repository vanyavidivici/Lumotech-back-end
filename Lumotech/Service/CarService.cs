using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service;

public sealed class CarService : ICarService
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

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync(CarParameters carParameters, bool trackChanges)
    {
        var cars = await _repository.Car.GetAllCarsAsync(carParameters, trackChanges);
            
        var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            
        return carsDto;
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsForUserAsync(string userId, CarParameters carParameters, bool trackChanges)
    {
        var cars = await _repository.Car.GetAllCarsForUserAsync(userId, carParameters, trackChanges);
            
        var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            
        return carsDto;
    }

    public async Task<CarDto> GetCarAsync(Guid id, bool trackChanges)
    {
        var car = await GetCarAndCheckIfItExists(id, trackChanges);
        
        var carDto = _mapper.Map<CarDto>(car);
        
        return carDto;
    }

    public async Task<CarDto> CreateCarAsync(string userId, CarForCreationDto car)
    {
        var carEntity = _mapper.Map<Car>(car);
        carEntity.UserId = userId;
        _repository.Car.CreateCar(carEntity);
        await _repository.SaveAsync();
        
        var carToReturn = _mapper.Map<CarDto>(carEntity);
        return carToReturn;
    }

    public async Task DeleteCarAsync(Guid id, bool trackChanges)
    {
        var company = await GetCarAndCheckIfItExists(id, trackChanges);
        
        _repository.Car.DeleteCar(company);
        await _repository.SaveAsync();
    }

    public async Task UpdateCarAsync(Guid carId, CarForUpdateDto carForUpdate, bool trackChanges)
    {
        var car = await GetCarAndCheckIfItExists(carId, trackChanges);
        
        _mapper.Map(carForUpdate, car);
        await _repository.SaveAsync();
    }

    private async Task<Car> GetCarAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var car = await _repository.Car.GetCarAsync(id, trackChanges);
        if (car is null)
            throw new CarNotFoundException(id);
        
        return car;
    }
}