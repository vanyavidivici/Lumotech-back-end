using Entities.Models;

namespace Repository.Extensions;

public static class RepositoryRobotStationExtensions
{
    public static IQueryable<RobotStation> Search(this IQueryable<RobotStation> robotStations, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return robotStations;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return robotStations.Where(e => e.StationName.ToLower().Contains(lowerCaseTerm));
    }
}