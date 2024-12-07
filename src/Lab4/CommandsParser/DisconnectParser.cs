using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class DisconnectParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "disconnect";
        var listArguments = args.ToList();

        if (!listArguments.Contains(command))
            return Next?.Parse(args) ?? new CommandType.Failure("Command 'disconnect' not found.");
        int commandIndex = args.IndexOf(command);
        args.RemoveAt(commandIndex);
        return new CommandType.Success();
    }
}