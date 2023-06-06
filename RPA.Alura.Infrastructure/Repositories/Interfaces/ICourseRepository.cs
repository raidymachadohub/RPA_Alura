using RPA.Alura.Domain.Model;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Infrastructure.Repositories.Interfaces;

public interface ICourseRepository
{
    Task<Result> AddCourseAsync(Courses course);
    Task<Result> AddCourseAsync(IEnumerable<Courses> course);
    
    Task<Result<IEnumerable<Courses>>> GetCoursesAsync();
    
}