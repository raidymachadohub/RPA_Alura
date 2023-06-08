using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Context;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using RPA.Alura.Shared.FlowControl.Enum;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Infrastructure.Repositories;

public class RoutineRepository : IRoutineRepository, IDisposable
{
    private readonly RPAContext _context;

    public RoutineRepository(RPAContext context)
    {
        _context = context;
    }

    public async Task<Result<IEnumerable<Routine>>> GetRoutineAsync()
    {
        if(_context.Routine == null)
            return Result.Fail<IEnumerable<Routine>>(new Error(ErrorType.Internal, "Object Routine is null"));
        
        var routines = await _context.Routine.Where(routine => routine.Active).AsQueryable().ToListAsync();
        
        if (routines == null)
            return Result.Fail<IEnumerable<Routine>>(new Error(ErrorType.NotFound, "Valor de rotina não encontrada"));
        
        return Result.Ok<IEnumerable<Routine>>(routines);
    }

    public async Task<Result> AddRoutineAsync(Routine routine)
    {
        try
        {
            if(_context.Routine == null)
                return Result.Fail(new Error(ErrorType.Internal, "Object Routine is null"));
            
            await _context.Routine.AddAsync(routine);
            await _context.SaveChangesAsync();
            
            Dispose();
            
            return Result.Ok(routine);
        }
        catch (Exception e)
        {
            return Result.Fail(new Error(ErrorType.Business, "Error: " + e.Message));
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}