using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public class WriteInError : IWriteIn
{
    public void PrintMessage(Message message)
    {
        Console.Error.WriteLine(message);
    }

    public void Clear()
    {
        Console.Clear();
    }
}