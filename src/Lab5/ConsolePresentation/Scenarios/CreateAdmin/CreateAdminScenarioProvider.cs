using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.CreateAdmin;

public class CreateAdminScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public CreateAdminScenarioProvider(IBankService service)
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

        scenario = new CreateAdminScenario(_service);
        return true;
    }
}