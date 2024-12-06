namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemVisitor;

public class FileSystemTraverser
{
    private readonly IFileSystem _fileSystem;

    public FileSystemTraverser(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Traverse(string path, IFileSystemVisitor visitor, int maxDepth, int currentDepth)
    {
        if (currentDepth > maxDepth)
            return;

        visitor.VisitDirectory(_fileSystem.GetFileName(path), currentDepth);

        string[] directories = _fileSystem.GetDirectories(path);
        foreach (string directory in directories)
        {
            Traverse(directory, visitor, maxDepth, currentDepth + 1);
        }

        string[] files = _fileSystem.GetFiles(path);
        foreach (string file in files)
        {
            visitor.VisitFile(Path.GetFileName(file), currentDepth + 1);
        }
    }
}