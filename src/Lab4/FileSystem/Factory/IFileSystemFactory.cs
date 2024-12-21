namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Factory;

public interface IFileSystemFactory
{
    IFileSystem CreateFileSystem(string absolutePath, string currentPath, string mode);
}