using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllCarsAsync(bool trackChanges);
    Task<CarDto> GetCarAsync(Guid carId, bool trackChanges);
}