using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class LoggingRecipientDecorator : RecipeintDecorator
{
    public LoggingRecipientDecorator(IRecipient recipient) : base(recipient) { }

    public override void SendMessage(Message message)
    {
        Console.WriteLine($"Logging: Sending message with header '{message.Header}' and body '{message.Body}'.");
        base.SendMessage(message);
    }
}