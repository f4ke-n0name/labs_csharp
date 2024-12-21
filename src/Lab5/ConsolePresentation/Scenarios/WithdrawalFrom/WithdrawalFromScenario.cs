using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.WithdrawalFrom;

public class WithdrawalFromScenario : IScenario
{
    private readonly IBankService _service;

    public WithdrawalFromScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Withdrawal";

    public async Task Run()
    {
        long account = AnsiConsole.Ask<long>("Enter the account number: ");
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount for replenishment: ");

        await _service
            .WithdrawalFrom(account, amount)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}