using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.Withdrawal;

public class WithdrawalScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public WithdrawalScenarioProvider(IBankService service)
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

        scenario = new WithdrawalScenario(_service);
        return true;
    }
}