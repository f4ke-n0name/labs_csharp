using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public class WriteInConsole : IWriteIn
{
    public void PrintMessage(Message message)
    {
        Console.WriteLine(message.ToString());
    }
}