using Contracts;
using Entities.Models;

namespace Repository;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Car> GetAllCars(bool trackChanges) => 
        FindAll(trackChanges)
        .OrderBy(c => c.CarModel)
        .ToList();
}