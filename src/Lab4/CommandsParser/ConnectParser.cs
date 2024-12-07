using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsParser;

public class ConnectParser : CommandParserBase
{
    public override CommandType Parse(IList<string> args)
    {
        const string command = "connect";
        const string modeFlag = "-m";
        var listArguments = args.ToList();

        if (!listArguments.Contains(command))
            return Next?.Parse(args) ?? new CommandType.Failure("Command 'connect' not found.");

        int commandIndex = listArguments.FindIndex(x => x == command);
        if (commandIndex + 1 >= listArguments.Count)
            return new CommandType.Failure("Address is missing for the 'connect' command.");

        string address = listArguments[commandIndex + 1];

        int modeIndex = listArguments.FindIndex(x => x == modeFlag);
        if (modeIndex == -1 || modeIndex + 1 >= listArguments.Count)
            return new CommandType.Failure("Invalid or missing mode.");

        string localMode = listArguments[modeIndex + 1];
        args.RemoveAt(modeIndex + 1);
        args.RemoveAt(modeIndex);
        args.RemoveAt(commandIndex + 1);
        args.RemoveAt(commandIndex);
        var factory = new FileSystemFactory();
        IFileSystem fileSystem = factory.CreateFileSystem(address, address, localMode);
        return new CommandType.Connect(address, localMode, fileSystem);
    }
}