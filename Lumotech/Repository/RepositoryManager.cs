using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICarRepository> _carRepository;
    private readonly Lazy<IRobotRepository> _robotRepository;
    private readonly Lazy<IRobotStationRepository> _robotStationRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<ISubscriptionRepository> _subscriptionRepository;
    private readonly Lazy<ILocationRepository> _locationRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _carRepository = new Lazy<ICarRepository>(() => new CarRepository(repositoryContext));
        _robotRepository = new Lazy<IRobotRepository>(() => new RobotRepository(repositoryContext));
        _robotStationRepository = new Lazy<IRobotStationRepository>(() => new RobotStationRepository(repositoryContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        _subscriptionRepository = new Lazy<ISubscriptionRepository>(() => new SubscriptionRepository(repositoryContext));
        _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
    }
    
    public ICarRepository Car => _carRepository.Value;
    public IRobotRepository Robot => _robotRepository.Value;
    public IRobotStationRepository RobotStation => _robotStationRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;
    public ISubscriptionRepository Subscription => _subscriptionRepository.Value;
    public ILocationRepository Location => _locationRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}