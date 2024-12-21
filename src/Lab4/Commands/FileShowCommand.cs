using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly string? _mode;

    public FileShowCommand(CommandType.FileShow commandType)
    {
        _path = commandType.Path;
        _mode = commandType.Mode;
    }

    public void Execute(IFileSystem fileSystem)
    {
        if (!fileSystem.FileExists(_path))
            throw new FileNotFoundException($"File not found: {_path}");

        if (_mode != "console")
            throw new NotSupportedException($"Mode '{_mode}' is not supported. Only 'console' mode is allowed.");
        fileSystem.ShowFile(_path);
    }
}