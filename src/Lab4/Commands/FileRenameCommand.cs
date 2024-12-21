using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(CommandType.FileRename commandType)
    {
        _path = commandType.Path;
        _newName = commandType.Path;
    }

    public void Execute(IFileSystem fileSystem)
    {
        if (!fileSystem.FileExists(_path))
            throw new FileNotFoundException($"File not found: {_path}");

        if (_newName == fileSystem.GetFileName(_path))
        {
            throw new InvalidOperationException("New name and previous name must be different.");
        }

        string directory = fileSystem.GetDirectoryName(_path) ?? throw new InvalidOperationException("Invalid path.");
        string newFilePath = fileSystem.Combine(directory, _newName);
        fileSystem.ChangeDirectory(newFilePath);
        fileSystem.MoveFile(_path, newFilePath);
    }
}