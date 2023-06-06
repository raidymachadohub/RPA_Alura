using RPA.Alura.Domain.Model;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Infrastructure.Facade.Interfaces;

public interface ISeleniumFacade
{
    Result<IEnumerable<Courses>> CaptureData(Routine routine);
}