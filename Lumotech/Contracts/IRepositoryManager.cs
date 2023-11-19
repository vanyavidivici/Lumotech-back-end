namespace Contracts;

public interface IRepositoryManager
{
    ICarRepository Car { get; }
    IRobotRepository Robot { get; }
    IRobotStationRepository RobotStation { get; }
    IOrderRepository Order { get; }
    ISubscriptionRepository Subscription { get; }
    ILocationRepository Location { get; }

    void Save();
}