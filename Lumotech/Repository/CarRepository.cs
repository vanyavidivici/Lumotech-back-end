using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync(CarParameters carParameters, bool trackChanges) =>
    await FindAll(trackChanges)
            .Search(carParameters.SearchTerm)
            .OrderBy(c => c.CarModel)
            .Skip((carParameters.PageNumber - 1) * carParameters.PageSize)
            .Take(carParameters.PageSize)
            .ToListAsync();
    
    public async Task<IEnumerable<Car>> 
        GetAllCarsForUserAsync(string userId, CarParameters carParameters, bool trackChanges) =>
        await FindAll(trackChanges)
            .Search(carParameters.SearchTerm)
            .OrderBy(c => c.CarModel)
            .Skip((carParameters.PageNumber - 1) * carParameters.PageSize)
            .Take(carParameters.PageSize)
            .ToListAsync();

    public async Task<Car> GetCarAsync(Guid carId, bool trackChanges) => 
        await FindByCondition(c => c.Id.Equals(carId), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateCar(Car car) => Create(car);
    public void DeleteCar(Car car) => Delete(car);
}