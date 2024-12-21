using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class TreeListParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "tree";
        const string subCommand = "list";
        const string depthFlag = "-d";
        const string formatFlag = "-p";
        int depth = 1;
        var style = new OutputStyle();
        var listArguments = args.ToList();

        if (listArguments.Count < 2 || !listArguments.Contains(command) || !listArguments.Contains(subCommand))
        {
            return Next?.Parse(args) ?? new CommandType.Failure("Command 'connect' not found.");
        }

        int depthFlagIndex = listArguments.FindIndex(x => x == depthFlag);
        if (depthFlagIndex != -1)
        {
            if (depthFlagIndex + 1 >= listArguments.Count || !int.TryParse(listArguments[depthFlagIndex + 1], out depth))
            {
                return new CommandType.Failure("Invalid depth value for '-d' flag.");
            }

            if (depth <= 0)
            {
                return new CommandType.Failure("Depth must be a positive integer.");
            }

            args.RemoveAt(depthFlagIndex + 1);
            args.RemoveAt(depthFlagIndex);
        }

        listArguments = args.ToList();
        int formatFlagIndex = listArguments.FindIndex(x => x == formatFlag);
        if (formatFlagIndex != -1)
        {
            if (formatFlagIndex + 2 >= listArguments.Count)
            {
                return new CommandType.Failure("Missing output format after '-p' flag.");
            }

            string formatFile = listArguments[formatFlagIndex + 1];
            string formatDirectory = listArguments[formatFlagIndex + 2];
            style = new OutputStyle(formatFile, formatDirectory);
            args.RemoveAt(formatFlagIndex + 2);
            args.RemoveAt(formatFlagIndex + 1);
            args.RemoveAt(formatFlagIndex);
        }

        args.Remove(command);
        args.Remove(subCommand);
        return new CommandType.TreeList(depth, style);
    }
}