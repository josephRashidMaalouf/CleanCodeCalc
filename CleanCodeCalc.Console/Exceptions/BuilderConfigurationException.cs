namespace CleanCodeCalc.Console.Exceptions;

public class BuilderConfigurationException(string errorMsg) : InvalidOperationException(errorMsg)
{

}