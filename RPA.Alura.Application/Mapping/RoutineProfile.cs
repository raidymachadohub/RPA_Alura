using AutoMapper;
using RPA.Alura.Domain.DTO;
using RPA.Alura.Domain.Model;

namespace RPA.Alura.Application.Mapping;

public class RoutineProfile : Profile
{
    public RoutineProfile()
    {
        CreateMap<Routine, RoutineDTO>()
            .ReverseMap();
    }
}