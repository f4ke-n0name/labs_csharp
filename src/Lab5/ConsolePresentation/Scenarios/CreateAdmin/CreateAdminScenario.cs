using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.CreateAdmin;

public class CreateAdminScenario : IScenario
{
    private readonly IBankService _service;

    public CreateAdminScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Create Admin";

    public async Task Run()
    {
        string firstName = AnsiConsole.Ask<string>("Enter the first name of account: ");
        string lastName = AnsiConsole.Ask<string>("Enter the last name of account: ");
        string password = AnsiConsole.Ask<string>("Enter the password of account: ");
        string systemName = AnsiConsole.Ask<string>("Enter the system name of account: ");
        await _service
            .CreateAdmin(firstName, lastName, systemName, password)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}