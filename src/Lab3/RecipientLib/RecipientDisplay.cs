using Itmo.ObjectOrientedProgramming.Lab3.DisplayLib;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientDisplay : IRecipient
{
    private readonly IDisplayDriver _display;

    public RecipientDisplay(IDisplayDriver display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        _display.PrintMessage(message);
    }
}