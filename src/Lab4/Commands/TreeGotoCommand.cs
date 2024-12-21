using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(CommandType.TreeGoto commandType)
    {
        _path = commandType.Path;
    }

    public void Execute(IFileSystem fileSystem)
    {
        if (!fileSystem.DirectoryExists(_path))
            throw new DirectoryNotFoundException($"Directory not found: {_path}");

        fileSystem.SetCurrentDirectory(_path);
    }
}