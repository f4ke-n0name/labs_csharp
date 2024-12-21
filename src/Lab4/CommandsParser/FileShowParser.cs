using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class FileShowParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "file";
        const string subCommand = "show";
        const string modeFlag = "-m";
        const string localMode = "console";
        var listArguments = args.ToList();

        if (listArguments.Count < 2 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
            return Next?.Parse(args) ?? new CommandType.Failure("Command 'file show' not found.");

        int subCommandIndex = listArguments.FindIndex(x => x == subCommand);
        if (subCommandIndex + 1 >= listArguments.Count)
            return new CommandType.Failure("Path is missing for the 'file show' command.");

        string path = listArguments[subCommandIndex + 1];

        int modeIndex = listArguments.FindIndex(x => x == modeFlag);
        if (modeIndex == -1 || modeIndex + 1 >= listArguments.Count || listArguments[modeIndex + 1] != localMode)
            return new CommandType.Failure("Invalid or missing mode. Only 'console' is supported.");

        args.RemoveAt(modeIndex + 1);
        args.RemoveAt(modeIndex);
        args.RemoveAt(subCommandIndex + 1);
        args.RemoveAt(subCommandIndex);
        args.RemoveAt(args.IndexOf(command));
        return new CommandType.FileShow(path, localMode);
    }
}