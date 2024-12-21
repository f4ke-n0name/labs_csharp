using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.Transactions;

public class TransactionsScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public TransactionsScenarioProvider(IBankService service)
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

        scenario = new TransactionsScenario(_service);
        return true;
    }
}