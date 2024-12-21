using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.WithdrawalFrom;

public class WithdrawalFromScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public WithdrawalFromScenarioProvider(IBankService service)
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

        scenario = new WithdrawalFromScenario(_service);
        return true;
    }
}