using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(CommandType.FileDelete commandType)
    {
        _path = commandType.Path;
    }

    public void Execute(IFileSystem fileSystem)
    {
        if (!fileSystem.FileExists(_path))
        {
            throw new FileNotFoundException($"File '{_path}' does not exist.");
        }

        if (fileSystem.DirectoryExists(_path))
        {
            throw new InvalidOperationException($"'{_path}' is , not a file.");
        }

        fileSystem.DeleteFile(_path);
    }
}