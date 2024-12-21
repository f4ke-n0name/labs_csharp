using Services.BankServices;
using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation.Scenarios.CreateUser;

public class CreateUserScenarioProvider : IScenarioProvider
{
    private readonly IBankService? _service;

    public CreateUserScenarioProvider(IBankService service)
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

        scenario = new CreateUserScenario(_service);
        return true;
    }
}