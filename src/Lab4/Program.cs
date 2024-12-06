using Itmo.ObjectOrientedProgramming.Lab4.Commands.Factory;
using Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;
using Itmo.ObjectOrientedProgramming.Lab4.Context;
using Itmo.ObjectOrientedProgramming.Lab4.ParsersType;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var connectParser = new ConnectParser();
        var treeListParser = new TreeListParser();
        var disconnectParser = new DisconnectParser();
        connectParser.SetNext(treeListParser).SetNext(disconnectParser);
        var consoleParser = new ConsoleParser(args);
        ICommandFactory commandFactory = new CommandFactory();
        var parserContext = new ParserContext(consoleParser, connectParser, commandFactory);
        IList<Commands.ICommand> results = parserContext.ConvertToCommands();
        var commandInvoker = new CommandsInvoker(results);
        commandInvoker.ExecuteCommands();
    }
}