using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.UserLogin;

public class UserLoginScenario : IScenario
{
    private readonly IBankService _service;

    public UserLoginScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "User Login";

    public async Task Run()
    {
        long account = AnsiConsole.Ask<long>("Enter the account number: ");
        short pinCode = AnsiConsole.Ask<short>("Enter the account pin code: ");
        await _service
            .UserLogin(account, pinCode)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}