using RPA.Alura.Domain.Model;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Services.Services.Interfaces;

public interface ICourseService
{
    Task<Result> AddCourseAsync(Courses course);
    Task<Result> AddCourseAsync(IEnumerable<Courses> course);
    Task<Result<IEnumerable<Courses>>> GetCoursesAsync();
}