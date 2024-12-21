using Services.BankServices;
using Spectre.Console;
using Utils.Models.Contracts;

namespace ConsolePresentation.Scenarios.HistoryOf;

public class HistoryOfScenario : IScenario
{
    private readonly IBankService _service;

    public HistoryOfScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "History Of";

    public async Task Run()
    {
        long account = AnsiConsole.Ask<long>("Enter the number of account: ");
        IEnumerable<ITransaction> history = await _service
            .HistoryOf(account)
            .ConfigureAwait(false);
        AnsiConsole.WriteLine("Account: " + account);
        foreach (ITransaction transaction in history)
        {
            AnsiConsole.WriteLine(transaction.Operation + " | " +
                                  transaction.Amount + " | " +
                                  transaction.DateTime);
        }

        AnsiConsole.WriteLine("Ok");
    }
}