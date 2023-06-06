using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Context;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using RPA.Alura.Shared.FlowControl.Enum;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository, IDisposable
{
    private readonly RPAContext _context;

    public CourseRepository(RPAContext context)
    {
        _context = context;
    }

    public async Task<Result> AddCourseAsync(Courses course)
    {
        try
        {
            if(_context.Courses == null)
                return Result.Fail(new Error(ErrorType.Internal, "Object Courses is null"));
            
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            Dispose();
            return Result.Ok(course);
        }
        catch (Exception e)
        {
            return Result.Fail(new Error(ErrorType.Business, "Error: " + e.Message));
        }
    }

    public async Task<Result> AddCourseAsync(IEnumerable<Courses> course)
    {
        try
        {
            if(_context.Courses == null)
                return Result.Fail(new Error(ErrorType.Internal, "Object Courses is null"));
            
            await _context.Courses.AddRangeAsync(course);
            await _context.SaveChangesAsync();
            
            Dispose();
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(new Error(ErrorType.Business, "Error: " + e.Message));
        }
    }

    public async Task<Result<IEnumerable<Courses>>> GetCoursesAsync()
    {
        if(_context.Courses == null)
            return Result.Fail<IEnumerable<Courses>>(new Error(ErrorType.Internal, "Object Course is null"));
        
        var routines = await _context.Courses.AsQueryable().ToListAsync();
        
        if (routines == null)
            return Result.Fail<IEnumerable<Courses>>(new Error(ErrorType.NotFound, "Valor de rotina não encontrada"));
        
        return Result.Ok<IEnumerable<Courses>>(routines);
    }

    /// <summary>
    /// Garbage Collector.
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }
}