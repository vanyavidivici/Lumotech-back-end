using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Lumotech;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>();
    }
}