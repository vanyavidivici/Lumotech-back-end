using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class RobotService : IRobotService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RobotService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RobotDto>> GetRobotsAsync(Guid robotStationId, bool trackChanges)
    {
        var robotStation = await _repository.RobotStation.GetRobotStationAsync(robotStationId, trackChanges);
        if (robotStation is null) 
            throw new RobotStationNotFoundException(robotStationId);
        
        var robotsFromDb = await _repository.Robot.GetRobotsAsync(robotStationId, trackChanges);
        var robotsDto = _mapper.Map<IEnumerable<RobotDto>>(robotsFromDb);
        
        return robotsDto;
    }

    public async Task<RobotDto> GetRobotAsync(Guid robotStationId, Guid id, bool trackChanges)
    {
        var robotStation = await _repository.RobotStation.GetRobotStationAsync(robotStationId, trackChanges);
        if (robotStation is null) 
            throw new RobotStationNotFoundException(robotStationId);
        
        var robotDb = await _repository.Robot.GetRobotAsync(robotStationId, id, trackChanges);
        if (robotDb is null)
            throw new RobotNotFoundException(id);
        
        var robot = _mapper.Map<RobotDto>(robotDb);
        return robot;
    }

    public async Task<RobotDto> CreateRobotForRobotStationAsync(Guid robotStationId, 
        RobotForCreationDto robotForCreation, bool trackChanges)
    {
        await CheckIfRobotStationExists(robotStationId, trackChanges);
        
        var robotEntity = _mapper.Map<Robot>(robotForCreation);
        
        _repository.Robot.CreateRobotForRobotStation(robotStationId, robotEntity);
        await _repository.SaveAsync();
        
        var employeeToReturn = _mapper.Map<RobotDto>(robotEntity);
        return employeeToReturn;
    }

    public async Task DeleteRobotForRobotStationAsync(Guid robotStationId, Guid id, bool trackChanges)
    {
        await CheckIfRobotStationExists(robotStationId, trackChanges);

        var robotDb = await GetRobotForRobotStationAndCheckIfItExists(robotStationId, id, trackChanges);
        
        _repository.Robot.DeleteRobot(robotDb);
        await _repository.SaveAsync();
    }

    private async Task CheckIfRobotStationExists(Guid robotStationId, bool trackChanges)
    {
        var robotStation = await _repository.RobotStation.GetRobotStationAsync(robotStationId, trackChanges);
        
        if (robotStation is null)
            throw new RobotStationNotFoundException(robotStationId);
    }
    
    private async Task<Robot> GetRobotForRobotStationAndCheckIfItExists(Guid robotStationId, Guid id, bool trackChanges)
    {
        var robotDb = await _repository.Robot.GetRobotAsync(robotStationId, id, trackChanges);
        if (robotDb is null)
            throw new RobotNotFoundException(id);

        return robotDb;
    }
}