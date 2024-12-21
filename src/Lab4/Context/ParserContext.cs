using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Factory;
using Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;
using Itmo.ObjectOrientedProgramming.Lab4.ParsersType;

namespace Itmo.ObjectOrientedProgramming.Lab4.Context;

public class ParserContext : IParserContext
{
    private readonly IParser _inputParser;
    private readonly ICommandFactory _commandFactory;

    private ICommandParser CommandParser { get; }

    public ParserContext(IParser inputParser, ICommandParser commandParser, ICommandFactory commandFactory)
    {
        _inputParser = inputParser;
        CommandParser = commandParser;
        _commandFactory = commandFactory;
    }

    public IList<ICommand> ConvertToCommands()
    {
        var args = _inputParser.ParseToStrings().ToList();
        var commands = new List<ICommand>();

        while (args.Count != 0)
        {
            CommandType commandType = CommandParser.Parse(args);
            ICommand command = _commandFactory.CreateCommand(commandType);
            commands.Add(command);
        }

        return commands;
    }
}