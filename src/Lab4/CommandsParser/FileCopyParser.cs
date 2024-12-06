using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class FileCopyParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "file";
        const string subCommand = "copy";
        var listArguments = args.ToList();

        if (listArguments.Count < 3 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
            return Next?.Parse(args) ?? new CommandType.Failure("Invalid or missing 'file copy' command.");

        int subCommandIndex = listArguments.FindIndex(x => x == subCommand);
        if (subCommandIndex + 2 >= listArguments.Count)
            return new CommandType.Failure("Missing source or destination path for 'file copy' command.");

        string sourcePath = listArguments[subCommandIndex + 1];
        string destinationPath = listArguments[subCommandIndex + 2];
        args.RemoveAt(subCommandIndex + 2);
        args.RemoveAt(subCommandIndex + 1);
        args.RemoveAt(subCommandIndex);
        args.RemoveAt(args.IndexOf(command));
        return new CommandType.FileCopy(sourcePath, destinationPath);
    }
}