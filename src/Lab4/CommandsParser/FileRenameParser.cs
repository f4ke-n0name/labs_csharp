using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class FileRenameParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "file";
        const string subCommand = "rename";
        var listArguments = args.ToList();

        if (listArguments.Count < 4 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
            return Next?.Parse(args) ?? new CommandType.Failure("Invalid command or missing arguments.");

        int subCommandIndex = listArguments.FindIndex(x => x == subCommand);
        if (subCommandIndex + 2 >= listArguments.Count)
            return new CommandType.Failure("Missing source path or new name for 'file rename' command.");

        string path = listArguments[subCommandIndex + 1];
        string name = listArguments[subCommandIndex + 2];
        args.RemoveAt(subCommandIndex + 2);
        args.RemoveAt(subCommandIndex + 1);
        args.RemoveAt(subCommandIndex);
        args.RemoveAt(args.IndexOf(command));
        return new CommandType.FileRename(path, name);
    }
}