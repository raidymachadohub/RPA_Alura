using AutoMapper;
using RPA.Alura.Domain.DTO;
using RPA.Alura.Domain.Model;

namespace RPA.Alura.Application.Mapping;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Courses, CoursesDTO>()
            .ReverseMap();
    }
}