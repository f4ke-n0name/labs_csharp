using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly OutputStyle _style;

    public TreeListCommand(CommandType.TreeList commandType)
    {
        _depth = commandType.Depth;
        _style = commandType.Style;
    }

    public void Execute(IFileSystem fileSystem)
    {
        string startDirectory = fileSystem.CurrentPath;
        var visitor = new TreeListVisitor(_depth, fileSystem);
        var traverser = new FileSystemTraverser(fileSystem);
        traverser.Traverse(startDirectory, visitor, _depth, 0, _style);
    }
}