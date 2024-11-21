using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public interface IDisplayDriver
{
    void PrintMessage(Message message);

    void Clear();

    void SetColour(string colour);
}