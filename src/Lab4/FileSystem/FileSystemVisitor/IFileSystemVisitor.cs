namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemVisitor;

public interface IFileSystemVisitor
{
    void VisitDirectory(string directoryName, int depth, OutputStyle style);

    void VisitFile(string fileName, int depth, OutputStyle style);
}