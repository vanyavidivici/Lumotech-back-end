using Contracts;
using Entities.Models;

namespace Repository;

public class RobotStationRepository : RepositoryBase<RobotStation>, IRobotStationRepository
{
    public RobotStationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}