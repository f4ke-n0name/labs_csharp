using Services.BankServices;
using Spectre.Console;
using Utils.Models.Contracts;

namespace ConsolePresentation.Scenarios.Transactions;

public class TransactionsScenario : IScenario
{
    private readonly IBankService _service;

    public TransactionsScenario(IBankService service)
    {
        _service = service;
    }

    public string Name => "Transactions";

    public async Task Run()
    {
        IEnumerable<ITransaction> history = await _service
            .Transactions()
            .ConfigureAwait(false);

        foreach (ITransaction transaction in history)
        {
            AnsiConsole.WriteLine(transaction.Operation + " | " +
                              transaction.Amount + " | " +
                              transaction.DateTime);
        }

        AnsiConsole.WriteLine("Ok");
    }
}