using RPA.Alura.Shared.FlowControl.Enum;

namespace RPA.Alura.Shared.FlowControl.Model;

public class Error
{
    public string Message { get; set; }
    public ErrorType ErrorType { get; set; }

    public Error(ErrorType errorType, string message)
    {
        ErrorType = errorType;
        Message = message;
    }
    
    public Error(string message)
    {
        Message = message;
    }
    public Error(){}
}