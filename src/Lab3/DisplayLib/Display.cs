using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public class Display : IDisplay
{
    private readonly ConsoleColor _colour;

    public Display(string inColour)
    {
        if (!Enum.TryParse(inColour, true, out ConsoleColor colour))
        {
            throw new ArgumentException("This color is not supported");
        }

        _colour = colour;
    }

    public void PrintMessage(Message message)
    {
        DisplayClear();

        Console.ForegroundColor = _colour;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void DisplayClear()
    {
        Console.Clear();
    }
}