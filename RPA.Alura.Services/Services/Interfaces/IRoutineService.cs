using RPA.Alura.Domain.Model;

namespace RPA.Alura.Services.Services.Interfaces;
using Shared.FlowControl.Model;

public interface IRoutineService
{
    Task<Result<IEnumerable<Routine>>> GetRoutineAsync();
    Task<Result> AddRoutineAsync(Routine routine);
}