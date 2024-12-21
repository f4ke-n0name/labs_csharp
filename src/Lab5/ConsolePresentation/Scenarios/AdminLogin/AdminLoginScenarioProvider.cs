using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.AdminLogin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public AdminLoginScenarioProvider(IBankService service)
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

        scenario = new AdminLoginScenario(_service);
        return true;
    }
}