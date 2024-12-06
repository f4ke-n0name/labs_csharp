using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(CommandType.TreeList commandType)
    {
        _depth = commandType.Depth;
    }

    public void Execute(IFileSystem fileSystem)
    {
        string startDirectory = fileSystem.CurrentPath;
        var visitor = new TreeListVisitor(_depth, fileSystem);
        var traverser = new FileSystemTraverser(fileSystem);
        traverser.Traverse(startDirectory, visitor, _depth, 0);
    }
}