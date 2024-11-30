using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public interface IDisplay
{
    void PrintMessage(Message message);

    void DisplayClear();
}