using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICarService> _carService;
    private readonly Lazy<IRobotService> _robotService;
    private readonly Lazy<IRobotStationService> _robotStationService;
    private readonly Lazy<ILocationService> _locationService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _carService = new Lazy<ICarService>(() => new CarService(repositoryManager, logger));
        _robotService = new Lazy<IRobotService>(() => new RobotService(repositoryManager, logger));
        _robotStationService = new Lazy<IRobotStationService>(() => new RobotStationService(repositoryManager, logger));
        _locationService = new Lazy<ILocationService>(() => new LocationService(repositoryManager, logger));
    }
    
    public ICarService CarService => _carService.Value;
    public IRobotService RobotService => _robotService.Value;
    public IRobotStationService RobotStationService => _robotStationService.Value;
    public ILocationService LocationService => _locationService.Value;
}