using CleanCodeCalc.Console.Models;
using System.Reflection.Metadata;

namespace CleanCodeCalc.Console.Handlers;

public abstract class InputHandlerBase : IInputHandler
{
    protected IInputHandler? Next;

    public IInputHandler SetNext(IInputHandler next)
    {
        Next = next;
        return next;
    }

    public virtual void Handle(InputData inputData)
    {
        if (Next is not null)
        {
            Next.Handle(inputData);
        }
    }
}
