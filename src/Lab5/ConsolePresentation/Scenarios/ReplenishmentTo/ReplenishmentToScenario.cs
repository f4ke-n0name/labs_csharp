using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.ReplenishmentTo;

public class ReplenishmentToScenario : IScenario
{
    private readonly IBankService _service;

    public ReplenishmentToScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Replenishment To";

    public async Task Run()
    {
        long userBankAccount = AnsiConsole.Ask<long>("Enter the number account for replenishment: ");
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount for replenishment: ");

        await _service
            .ReplenishmentTo(userBankAccount, amount)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}