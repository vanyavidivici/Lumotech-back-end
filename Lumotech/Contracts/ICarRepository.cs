using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllCarsAsync(CarParameters carParameters, bool trackChanges);
    Task<IEnumerable<Car>> GetAllCarsForUserAsync(string userId, CarParameters carParameters, bool trackChanges);
    Task<Car> GetCarAsync(Guid carId, bool trackChanges);
    void CreateCar(Car car);
    void DeleteCar(Car car);
}