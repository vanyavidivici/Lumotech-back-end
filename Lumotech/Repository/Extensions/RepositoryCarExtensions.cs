using Entities.Models;

namespace Repository.Extensions;

public static class RepositoryCarExtensions
{
    public static IQueryable<Car> FilterEmployees(this IQueryable<Car> cars, double minCapacity, double maxCapacity) =>
        cars.Where(e => (e.BatteryCapacity >= minCapacity && e.BatteryCapacity <= maxCapacity));
    
    public static IQueryable<Car> Search(this IQueryable<Car> cars, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return cars;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return cars.Where(e => e.CarModel.ToLower().Contains(lowerCaseTerm));
    }
}