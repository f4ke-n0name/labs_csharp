using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.Withdrawal;

public class WithdrawalScenario : IScenario
{
    private readonly IBankService _service;

    public WithdrawalScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Withdrawal";

    public async Task Run()
    {
        long account = AnsiConsole.Ask<long>("Enter the account number: ");
        await _service
            .Withdrawal(account)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}