using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.HistoryOf;

public class HistoryOfScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public HistoryOfScenarioProvider(IBankService service)
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

        scenario = new HistoryOfScenario(_service);
        return true;
    }
}