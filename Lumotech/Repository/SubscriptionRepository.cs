using Contracts;
using Entities.Models;

namespace Repository;

public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}