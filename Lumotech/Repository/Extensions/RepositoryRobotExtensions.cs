using System.Linq.Dynamic.Core;
using Entities.Models;
using Repository.Extensions.Utility;

namespace Repository.Extensions;

public static class RepositoryRobotExtensions
{
    public static IQueryable<Robot> Search(this IQueryable<Robot> robots, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return robots;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return robots.Where(e => e.SerialNumber.ToLower().Contains(lowerCaseTerm));
    }
    
    public static IQueryable<Robot> Sort(this IQueryable<Robot> robots, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return robots.OrderBy(e => e.SerialNumber);
        
        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Robot>(orderByQueryString);
        
        if (string.IsNullOrWhiteSpace(orderQuery))
            return robots.OrderBy(e => e.SerialNumber);
        
        return robots.OrderBy(orderQuery);
    }
}