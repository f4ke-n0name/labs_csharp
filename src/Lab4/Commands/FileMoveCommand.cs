using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(CommandType.FileMove commandType)
    {
        _sourcePath = commandType.SourcePath;
        _destinationPath = commandType.DestinationPath;
    }

    public void Execute(IFileSystem fileSystem)
    {
        if (!fileSystem.FileExists(_sourcePath))
        {
            throw new FileNotFoundException($"The source file '{_sourcePath}' does not exist.");
        }

        string? destinationDirectory = fileSystem.GetDirectoryName(_destinationPath);
        if (destinationDirectory != null && !fileSystem.DirectoryExists(destinationDirectory))
        {
            throw new DirectoryNotFoundException($"The destination directory '{destinationDirectory}' does not exist.");
        }

        fileSystem.MoveFile(_sourcePath, _destinationPath);
    }
}