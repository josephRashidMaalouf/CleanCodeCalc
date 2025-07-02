using CleanCodeCalc.Console.Models;

namespace CleanCodeCalc.Console.Handlers;

public interface IInputHandler
{
    IInputHandler SetNext(IInputHandler next);
    void Handle(InputData inputData);
}