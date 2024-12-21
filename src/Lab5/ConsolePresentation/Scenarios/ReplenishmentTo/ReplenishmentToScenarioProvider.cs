using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.ReplenishmentTo;

public class ReplenishmentToScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public ReplenishmentToScenarioProvider(IBankService service)
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

        scenario = new ReplenishmentToScenario(_service);
        return true;
    }
}