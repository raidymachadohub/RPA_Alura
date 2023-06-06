using RPA.Alura.Domain.Model;
using RPA.Alura.Shared.FlowControl.Model;

namespace RPA.Alura.Services.Services.Interfaces;

public interface ISeleniumService
{
    Task<Result> CaptureData();
}