using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

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

    public async Task<IEnumerable<RobotStationDto>> GetAllRobotStationsAsync(RobotStationParameters robotStationParameters, 
        bool trackChanges)
    {
        var robotStations = 
            await _repository.RobotStation.GetAllRobotStationsAsync(robotStationParameters, trackChanges);
            
        var robotStationsDto = _mapper.Map<IEnumerable<RobotStationDto>>(robotStations);
            
        return robotStationsDto;
    }

    public async Task<RobotStationDto> GetRobotStationAsync(Guid id, bool trackChanges)
    {
        var robotStation = await GetRobotStationAndCheckIfItExists(id, trackChanges);
        
        var robotStationDto = _mapper.Map<RobotStationDto>(robotStation);
        
        return robotStationDto;
    }

    public async Task<RobotStationDto> CreateRobotStationAsync(RobotStationForCreationDto robotStation)
    {
        var robotStationEntity = _mapper.Map<RobotStation>(robotStation);
        
        _repository.RobotStation.CreateRobotStation(robotStationEntity);
        await _repository.SaveAsync();
        
        var robotStationToReturn = _mapper.Map<RobotStationDto>(robotStationEntity);
        return robotStationToReturn;
    }

    public async Task DeleteRobotStationAsync(Guid id, bool trackChanges)
    {
        var robotStation = await GetRobotStationAndCheckIfItExists(id, trackChanges);
        
        _repository.RobotStation.DeleteRobotStation(robotStation);
        await _repository.SaveAsync();
    }

    public async Task UpdateRobotStationAsync(Guid robotStationId, RobotStationForUpdateDto robotStationForUpdate, bool trackChanges)
    {
        var robotStation = await GetRobotStationAndCheckIfItExists(robotStationId, trackChanges);

        _mapper.Map(robotStationForUpdate, robotStation);
        await _repository.SaveAsync();
    }

    private async Task<RobotStation> GetRobotStationAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var robotStation = await _repository.RobotStation.GetRobotStationAsync(id, trackChanges);
        if (robotStation is null)
            throw new RobotStationNotFoundException(id);
        
        return robotStation;
    }
}