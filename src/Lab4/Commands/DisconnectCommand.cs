using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(IFileSystem fileSystem)
    {
        fileSystem.Disconnect();
    }
}