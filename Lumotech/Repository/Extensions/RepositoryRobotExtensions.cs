using Entities.Models;

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
}