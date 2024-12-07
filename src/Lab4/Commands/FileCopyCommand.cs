using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;
    private string _destinationPath;

    public FileCopyCommand(CommandType.FileCopy commandType)
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

        if (fileSystem.DirectoryExists(_destinationPath))
        {
            _destinationPath = fileSystem.Combine(_destinationPath, fileSystem.GetFileName(_sourcePath));
        }

        if (fileSystem.FileExists(_destinationPath))
        {
            throw new IOException($"The destination file '{_destinationPath}' already exists.");
        }

        fileSystem.CopyFile(_sourcePath, _destinationPath);
    }
}