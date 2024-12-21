using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.Replenishment;

public class ReplenishmentScenario : IScenario
{
    private readonly IBankService _service;

    public ReplenishmentScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Replenishment";

    public async Task Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount for replenishment: ");

        await _service
            .Replenishment(amount)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Ok");
    }
}