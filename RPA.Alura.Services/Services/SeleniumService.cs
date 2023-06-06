using RPA.Alura.Domain.Model;
using RPA.Alura.Infrastructure.Facade.Interfaces;
using RPA.Alura.Services.Services.Interfaces;
using RPA.Alura.Shared.FlowControl.Enum;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Services.Services;

public class SeleniumService : ISeleniumService
{
    private readonly IRoutineService _routineService;
    private readonly ICourseService _courseService;

    private readonly ISeleniumFacade _seleniumFacade;

    public SeleniumService(IRoutineService routineService,
                           ICourseService courseService,
                           ISeleniumFacade seleniumFacade)
    {
        _routineService = routineService;
        _courseService = courseService;
        _seleniumFacade = seleniumFacade;
    }
    
    public async Task<Result> CaptureData()
    {
        var routines = await _routineService.GetRoutineAsync();
        
        if (!routines.Success)
            return Result.Fail<IEnumerable<Courses>>(new Error(ErrorType.NotFound, ""));
        
        if(!routines.Value.Any())
            return Result.Fail<IEnumerable<Courses>>(new Error(ErrorType.NotFound, ""));
        
        foreach (var routine in routines.Value)
        {
            var course = _seleniumFacade.CaptureData(routine);

            _courseService.AddCourseAsync(course.Value);

            routine.Active = false;

            await _routineService.AddRoutineAsync(routine);
        }

        return Result.Ok("Importado");
    }
}