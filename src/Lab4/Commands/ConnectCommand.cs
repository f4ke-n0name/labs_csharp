using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    public IFileSystem FileSystem { get; }

    public string? Mode { get; }

    private readonly string _address;

    public ConnectCommand(CommandType.Connect commandType)
    {
        _address = commandType.Address;
        Mode = commandType.Mode;
        FileSystem = commandType.FileSystem;
    }

    public void Execute(IFileSystem fileSystem)
    {
        fileSystem.SetCurrentDirectory(_address);
    }
}