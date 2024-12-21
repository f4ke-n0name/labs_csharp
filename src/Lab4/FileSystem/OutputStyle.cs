namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class OutputStyle
{
    public string FileStyle { get; }

    public string DirectoryStyle { get; }

    public OutputStyle(string fileStyle = "[F] ", string directoryStyle = "[D] ")
    {
        FileStyle = fileStyle;
        DirectoryStyle = directoryStyle;
    }
}