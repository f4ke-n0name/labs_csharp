using Services.BankServices;
using Spectre.Console;
using Utils.Models.Contracts;

namespace ConsolePresentation.Scenarios.CreateUser;

public class CreateUserScenario : IScenario
{
    private readonly IBankService _service;

    public CreateUserScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Create User";

    public async Task Run()
    {
        string firstName = AnsiConsole.Ask<string>("Enter the first name of account: ");
        string lastName = AnsiConsole.Ask<string>("Enter the last name of account: ");
        IUserResult user = await _service
            .CreateUser(firstName, lastName)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine($"User Created:\nBank account: {user.UserAccount}\nPin{user.PinCode}");
        AnsiConsole.WriteLine("Ok");
    }
}