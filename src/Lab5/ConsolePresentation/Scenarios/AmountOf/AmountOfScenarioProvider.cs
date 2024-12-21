using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.AmountOf;

public class AmountOfScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public AmountOfScenarioProvider(IBankService service)
    {
        _service = service;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_service is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AmountOfScenario(_service);
        return true;
    }
}