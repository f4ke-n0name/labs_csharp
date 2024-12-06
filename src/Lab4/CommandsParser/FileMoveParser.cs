using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class FileMoveParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "file";
        const string subCommand = "move";
        var listArguments = args.ToList();

        if (listArguments.Count < 4 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
            return Next?.Parse(args) ?? new CommandType.Failure("Invalid or missing 'file move' command.");

        int subCommandIndex = listArguments.FindIndex(x => x == subCommand);
        if (subCommandIndex + 2 >= listArguments.Count)
            return new CommandType.Failure("Missing source or destination path for 'file move' command.");

        string sourcePath = listArguments[subCommandIndex + 1];
        string destinationPath = listArguments[subCommandIndex + 2];
        args.RemoveAt(subCommandIndex + 2);
        args.RemoveAt(subCommandIndex + 1);
        args.RemoveAt(subCommandIndex);
        args.RemoveAt(args.IndexOf(command));
        return new CommandType.FileMove(sourcePath, destinationPath);
    }
}