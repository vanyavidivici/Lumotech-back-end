using Contracts;
using Entities.Models;

namespace Repository;

public class RobotRepository : RepositoryBase<Robot>, IRobotRepository
{
    public RobotRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}