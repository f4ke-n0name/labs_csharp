using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.Replenishment;

public class ReplenishmentScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public ReplenishmentScenarioProvider(IBankService service)
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

        scenario = new ReplenishmentScenario(_service);
        return true;
    }
}