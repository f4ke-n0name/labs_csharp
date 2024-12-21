using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public UserLoginScenarioProvider(IBankService service)
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

        scenario = new UserLoginScenario(_service);
        return true;
    }
}