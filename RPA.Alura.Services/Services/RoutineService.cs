using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Repositories.Interfaces;
using RPA.Alura.Services.Services.Interfaces;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Services.Services;

public class RoutineService : IRoutineService
{
    private readonly IRoutineRepository _routineRepository;
    
    public RoutineService(IRoutineRepository routineRepository)
    {
        _routineRepository = routineRepository;
    }
    public async Task<Result<IEnumerable<Routine>>> GetRoutineAsync()
    {
        return await _routineRepository.GetRoutineAsync();
    }

    public async Task<Result> AddRoutineAsync(Routine routine)
    {
        return await _routineRepository.AddRoutineAsync(routine);
    }
}