using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IBankService _service;

    public AdminLoginScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Admin Login";

    public async Task Run()
    {
        string userName = AnsiConsole.Ask<string>("Enter user name:");
        string password = AnsiConsole.Ask<string>("Enter password:");
        await _service.AdminLogin(userName, password).ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}