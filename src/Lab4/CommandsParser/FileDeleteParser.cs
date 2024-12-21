using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class FileDeleteParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "file";
        const string subCommand = "delete";
        var listArguments = args.ToList();

        if (listArguments.Count < 3 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
            return Next?.Parse(args) ?? new CommandType.Failure("Invalid or missing 'file delete' command.");

        int subCommandIndex = listArguments.FindIndex(x => x == subCommand);
        if (subCommandIndex + 2 >= listArguments.Count)
            return new CommandType.Failure("Missing source or destination path for 'file delete' command.");

        string path = listArguments[subCommandIndex + 1];
        args.RemoveAt(subCommandIndex + 1);
        args.RemoveAt(subCommandIndex);
        args.RemoveAt(args.IndexOf(command));
        return new CommandType.FileDelete(path);
    }
}