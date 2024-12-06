using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    void Execute(IFileSystem fileSystem);
}