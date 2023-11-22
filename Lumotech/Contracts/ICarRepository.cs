using Entities.Models;

namespace Contracts;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllCarsAsync(bool trackChanges);
    Task<Car> GetCarAsync(Guid carId, bool trackChanges);
}