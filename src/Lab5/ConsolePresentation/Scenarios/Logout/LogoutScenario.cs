using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.Logout;

public class LogoutScenario : IScenario
{
    private readonly IBankService _service;

    public LogoutScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Logout";

    public Task Run()
    {
        _service.Logout();
        AnsiConsole.WriteLine("Ok");
        return Task.CompletedTask;
    }
}