using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using RPA.Alura.Services.Services.Interfaces;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Services.Services;
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<Result> AddCourseAsync(Courses course)
    {
        return await _courseRepository.AddCourseAsync(course);
    }

    public async Task<Result> AddCourseAsync(IEnumerable<Courses> course)
    {
        return await _courseRepository.AddCourseAsync(course);
    }

    public async Task<Result<IEnumerable<Courses>>> GetCoursesAsync()
    {
        return await _courseRepository.GetCoursesAsync();
    }
}