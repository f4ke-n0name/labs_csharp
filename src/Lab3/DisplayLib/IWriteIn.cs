using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;

public interface IWriteIn
{
    void PrintMessage(Message message);

    void Clear();
}