using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;
using Itmo.ObjectOrientedProgramming.Lab3.MessangerLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientMessanger : IRecipient
{
    private readonly IMessenger _messenger;

    public RecipientMessanger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        _messenger.SendMessageInService(message.Body);
        Console.WriteLine($"Message sent to recipient with header: '{message.Header}' and body: '{message.Body}' using the messenger.");
    }
}