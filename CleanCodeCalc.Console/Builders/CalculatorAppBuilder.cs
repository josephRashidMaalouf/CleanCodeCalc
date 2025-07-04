using CleanCodeCalc.Console.Exceptions;
using CleanCodeCalc.Console.Handlers;

namespace CleanCodeCalc.Console.Builders;

public class CalculatorAppBuilder
{
    private readonly List<IInputHandler> _handlers = [];

    public CalculatorAppBuilder AddHandler(IInputHandler handler)
    {
        _handlers.Add(handler);
        return this;
    }

    public CalculatorProgram Build()
    {
        if (!_handlers.Any())
        {
            throw new BuilderConfigurationException("At least one handler needs to be added before build");
        }

        for (int i = 0; i < _handlers.Count - 1; i++)
        {
            _handlers[i].SetNext(_handlers[i + 1]);
        }

        return new CalculatorProgram(_handlers[0]);
    }
}