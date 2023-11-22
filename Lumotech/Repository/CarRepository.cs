using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync(bool trackChanges) => 
        await FindAll(trackChanges)
        .OrderBy(c => c.CarModel)
        .ToListAsync();

    public async Task<Car> GetCarAsync(Guid carId, bool trackChanges) => 
        await FindByCondition(c => c.Id.Equals(carId), trackChanges)
            .SingleOrDefaultAsync();
}