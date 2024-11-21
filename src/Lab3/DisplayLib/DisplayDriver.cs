using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public class DisplayDriver : IDisplayDriver
{
    private readonly IWriteIn _format;

    public string Colour { get; private set; }

    public DisplayDriver(string filePath, IWriteIn format, string colour)
    {
        _format = format;
        Colour = colour;
    }

    public void SetColour(string colour)
    {
        Colour = colour;
    }

    public void PrintMessage(Message message)
    {
        Console.ForegroundColor = Enum.Parse<ConsoleColor>(Colour, true);
        _format.PrintMessage(message);
        Console.ResetColor();
    }

    public void Clear()
    {
        Console.Clear();
    }
}