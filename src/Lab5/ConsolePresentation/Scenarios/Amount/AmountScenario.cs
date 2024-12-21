using Services.BankServices;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.Amount;

public class AmountScenario : IScenario
{
    private readonly IBankService _service;

    public AmountScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Amount";

    public async Task Run()
    {
        AnsiConsole.WriteLine(await _service.GetCashAmount().ConfigureAwait(false));
        AnsiConsole.WriteLine("Ok");
    }
}