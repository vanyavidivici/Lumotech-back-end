using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICarService
{
    IEnumerable<CarDto> GetAllCars(bool trackChanges);
}