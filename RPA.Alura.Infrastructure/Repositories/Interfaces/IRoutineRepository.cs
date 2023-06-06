using RPA.Alura.Domain.Model;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Infrastructure.Repositories.Interfaces;

public interface IRoutineRepository
{
    Task<Result<IEnumerable<Routine>>> GetRoutineAsync();
    Task<Result> AddRoutineAsync(Routine routine);
}