using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.Amount;

public class AmountScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public AmountScenarioProvider(IBankService service)
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

        scenario = new AmountScenario(_service);
        return true;
    }
}