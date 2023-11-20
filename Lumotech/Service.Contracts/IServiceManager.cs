namespace Service.Contracts;

public interface IServiceManager
{
    ICarService CarService { get; }
    IRobotService RobotService { get; }
    IRobotStationService RobotStationService { get; }
    ILocationService LocationService { get; }
}