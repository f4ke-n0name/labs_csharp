namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemVisitor;

public class TreeListVisitor : IFileSystemVisitor
{
    private readonly int _depth;
    private readonly IFileSystem _fileSystem;

    public TreeListVisitor(int depth, IFileSystem fileSystem)
    {
        _depth = depth;
        _fileSystem = fileSystem;
    }

    public void VisitDirectory(string directoryName, int depth, OutputStyle style)
    {
        if (depth <= _depth)
        {
            _fileSystem.Write($"{new string(' ', depth * 2)}{style.DirectoryStyle}{directoryName}");
        }
    }

    public void VisitFile(string fileName, int depth, OutputStyle style)
    {
        _fileSystem.Write($"{new string(' ', depth * 2)}{style.FileStyle}{fileName}");
    }
}