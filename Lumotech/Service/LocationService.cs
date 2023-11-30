using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class LocationService : ILocationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public LocationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync(bool trackChanges)
    {
        var locations = await _repository.Location.GetAllLocationsAsync(trackChanges);
            
        var locationsDto = _mapper.Map<IEnumerable<LocationDto>>(locations);
            
        return locationsDto;
    }

    public async Task<LocationDto> GetLocationAsync(Guid id, bool trackChanges)
    {
        var location = await GetLocationAndCheckIfItExists(id, trackChanges);
        
        var locationDto = _mapper.Map<LocationDto>(location);
        
        return locationDto;
    }

    public async Task<LocationDto> CreateLocationAsync(LocationForCreationDto location)
    {
        var locationEntity = _mapper.Map<Location>(location);
        
        _repository.Location.CreateLocation(locationEntity);
        await _repository.SaveAsync();
        
        var locationToReturn = _mapper.Map<LocationDto>(locationEntity);
        return locationToReturn;
    }

    public async Task DeleteLocationAsync(Guid id, bool trackChanges)
    {
        var location = await GetLocationAndCheckIfItExists(id, trackChanges);
        
        _repository.Location.DeleteLocation(location);
        await _repository.SaveAsync();
    }

    public async Task UpdateLocationAsync(Guid locationId, LocationForUpdateDto locationForUpdate, bool trackChanges)
    {
        var location = await GetLocationAndCheckIfItExists(locationId, trackChanges);

        _mapper.Map(locationForUpdate, location);
        await _repository.SaveAsync();
    }
    
    private async Task<Location> GetLocationAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var location = await _repository.Location.GetLocationAsync(id, trackChanges);
        if (location is null)
            throw new LocationNotFoundException(id);
        
        return location;
    }
}