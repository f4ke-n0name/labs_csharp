using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class TreeListParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "tree";
        const string subCommand = "list";
        const string depthFlag = "-d";
        int depth = 1;
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

        args.Remove(command);
        args.Remove(subCommand);
        return new CommandType.TreeList(depth);
    }
}