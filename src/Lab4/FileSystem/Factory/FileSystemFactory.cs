namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Factory;

public class FileSystemFactory : IFileSystemFactory
{
    public IFileSystem CreateFileSystem(string absolutePath, string currentPath, string mode)
    {
        return mode switch
        {
            "local" => new LocalFileSystem(absolutePath, currentPath),
            _ => throw new ArgumentException($"Unknown mode: {mode}"),
        };
    }
}