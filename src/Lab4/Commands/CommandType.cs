using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record class CommandType()
{
    public sealed record Success() : CommandType;

    public sealed record Failure(string ErrorMessage) : CommandType;

    public sealed record Connect(string Address, string? Mode, IFileSystem FileSystem) : CommandType;

    public sealed record FileCopy(string SourcePath, string DestinationPath) : CommandType;

    public sealed record FileDelete(string Path) : CommandType;

    public sealed record FileMove(string SourcePath, string DestinationPath) : CommandType;

    public sealed record FileRename(string Path, string Name) : CommandType;

    public sealed record FileShow(string Path, string? Mode) : CommandType;

    public sealed record TreeGoto(string Path) : CommandType;

    public sealed record TreeList(int Depth, OutputStyle Style) : CommandType;
}