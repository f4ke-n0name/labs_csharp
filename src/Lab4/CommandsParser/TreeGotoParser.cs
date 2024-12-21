using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class TreeGotoParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "tree";
        const string subCommand = "goto";
        var listArguments = args.ToList();

        if (listArguments.Count < 3 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
        {
            return Next?.Parse(args) ?? new CommandType.Failure("Invalid command or missing arguments.");
        }

        int subCommandIndex = listArguments.FindIndex(x => x == subCommand);
        if (subCommandIndex + 1 >= listArguments.Count)
        {
            return new CommandType.Failure("Missing path for 'tree goto' command.");
        }

        string path = listArguments[subCommandIndex + 1];
        args.RemoveAt(subCommandIndex + 1);
        args.RemoveAt(subCommandIndex);
        args.RemoveAt(args.IndexOf(command));
        return new CommandType.TreeGoto(path);
    }
}