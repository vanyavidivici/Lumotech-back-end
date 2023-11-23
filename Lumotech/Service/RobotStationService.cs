using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class RobotStationService : IRobotStationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RobotStationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RobotStationDto>> GetAllRobotStationsAsync(bool trackChanges)
    {
        var robotStations  = await _repository.RobotStation.GetAllRobotStationsAsync(trackChanges);
            
        var robotStationsDto = _mapper.Map<IEnumerable<RobotStationDto>>(robotStations);
            
        return robotStationsDto;
    }

    public async Task<RobotStationDto> GetRobotStationAsync(Guid id, bool trackChanges)
    {
        var robotStation = await _repository.RobotStation.GetRobotStationAsync(id, trackChanges);
        if (robotStation is null) 
            throw new RobotStationNotFoundException(id);
        
        var robotStationDto = _mapper.Map<RobotStationDto>(robotStation);
        
        return robotStationDto;
    }

    public async Task<RobotStationDto> CreateRobotStation(RobotStationForCreationDto robotStation)
    {
        var robotStationEntity = _mapper.Map<RobotStation>(robotStation);
        
        _repository.RobotStation.CreateRobotStation(robotStationEntity);
        await _repository.SaveAsync();
        
        var robotStationToReturn = _mapper.Map<RobotStationDto>(robotStationEntity);
        return robotStationToReturn;
    }
}