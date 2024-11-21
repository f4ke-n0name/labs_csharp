using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public class Display : IDisplay
{
    private readonly string _colour;

    public Display(string colour)
    {
        _colour = colour;
    }

    public void PrintMessage(Message message)
    {
        DisplayClear();
        if (!Enum.TryParse(_colour, true, out ConsoleColor colour))
            throw new ArgumentException("This color is not supported");

        Console.ForegroundColor = colour;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void DisplayClear()
    {
        Console.Clear();
    }
}