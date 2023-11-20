using Entities.Models;

namespace Service.Contracts;

public interface ICarService
{
    IEnumerable<Car> GetAllCars(bool trackChanges);
}