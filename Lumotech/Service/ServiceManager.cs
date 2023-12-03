using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICarService> _carService;
    private readonly Lazy<IRobotService> _robotService;
    private readonly Lazy<IRobotStationService> _robotStationService;
    private readonly Lazy<ILocationService> _locationService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IUserService> _userService;
    
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, 
        UserManager<User> userManager, IConfiguration configuration)
    {
        _carService = new Lazy<ICarService>(() => new CarService(repositoryManager, logger, mapper));
        _robotService = new Lazy<IRobotService>(() => new RobotService(repositoryManager, logger, mapper));
        _robotStationService = new Lazy<IRobotStationService>(() => new RobotStationService(repositoryManager,
            logger, mapper));
        _locationService = new Lazy<ILocationService>(() => new LocationService(repositoryManager, logger, 
            mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() => 
            new AuthenticationService(logger, mapper, userManager, configuration));
        _userService = new Lazy<IUserService>(() => 
            new UserService(logger, mapper, userManager, configuration));
    }
    
    public ICarService CarService => _carService.Value;
    public IRobotService RobotService => _robotService.Value;
    public IRobotStationService RobotStationService => _robotStationService.Value;
    public ILocationService LocationService => _locationService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IUserService UserService => _userService.Value;
}