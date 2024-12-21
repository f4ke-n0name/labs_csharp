using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.AmountOf;

public class AmountOfScenario : IScenario
{
    private readonly IBankService _service;

    public AmountOfScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Amount Of";

    public async Task Run()
    {
        long number = AnsiConsole.Ask<long>("Enter the number of account: ");
        AnsiConsole.WriteLine(
            await _service
                .GetCashAmountOf(number)
                .ConfigureAwait(false));
        AnsiConsole.WriteLine("Ok");
    }
}