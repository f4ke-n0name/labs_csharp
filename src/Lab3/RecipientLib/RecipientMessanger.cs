using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;
using Itmo.ObjectOrientedProgramming.Lab3.MessangerLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientMessanger : IRecipient
{
    private readonly IMessanger _messanger;

    public RecipientMessanger(IMessanger messanger)
    {
        _messanger = messanger;
    }

    public void SendMessage(Message message)
    {
        _messanger.SendMessageInService(message.Body);
        Console.WriteLine($"Message sent to recipient with header: '{message.Header}' and body: '{message.Body}' using the messenger.");
    }
}