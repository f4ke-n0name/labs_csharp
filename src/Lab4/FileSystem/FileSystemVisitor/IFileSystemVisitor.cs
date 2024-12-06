namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemVisitor;

public interface IFileSystemVisitor
{
    void VisitDirectory(string directoryName, int depth);

    void VisitFile(string fileName, int depth);
}