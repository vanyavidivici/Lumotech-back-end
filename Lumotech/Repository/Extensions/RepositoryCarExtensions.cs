using System.Linq.Dynamic.Core;
using Entities.Models;
using Repository.Extensions.Utility;

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
    
    public static IQueryable<Car> Sort(this IQueryable<Car> cars, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return cars.OrderBy(e => e.CarModel);
        
        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Car>(orderByQueryString);
        
        if (string.IsNullOrWhiteSpace(orderQuery))
            return cars.OrderBy(e => e.CarModel);
        
        return cars.OrderBy(orderQuery);
    }
}