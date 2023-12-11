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
        CreateMap<Location, LocationDto>();
        CreateMap<User, UserDto>();
        CreateMap<Order, OrderDto>();
        CreateMap<CarForCreationDto, Car>();
        CreateMap<RobotStationForCreationDto, RobotStation>();
        CreateMap<RobotForCreationDto, Robot>();
        CreateMap<LocationForCreationDto, Location>();
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<OrderForCreationDto, Order>();
        CreateMap<CarForUpdateDto, Car>();
        CreateMap<RobotStationForUpdateDto, RobotStation>();
        CreateMap<RobotForUpdateDto, Robot>();
        CreateMap<LocationForUpdateDto, Location>();
        CreateMap<OrderForUpdateDto, Order>();
    }
}