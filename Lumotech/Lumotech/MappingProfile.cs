using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Lumotech;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<RobotStation, RobotStationDto>();
        CreateMap<Robot, RobotDto>();
        CreateMap<CarForCreationDto, Car>();
        CreateMap<RobotStationForCreationDto, RobotStation>();
        CreateMap<RobotForCreationDto, Robot>();
    }
}