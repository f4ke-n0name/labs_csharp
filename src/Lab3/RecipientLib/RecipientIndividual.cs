using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientIndividual : IRecipient
{
    private readonly string _name;

    public RecipientIndividual(string name)
    {
        _name = name;
    }

    public void SendMessage(Message message)
    {
        Console.WriteLine($"Sending message to {_name}: Header: '{message.Header}', Body: '{message.Body}'");
    }
}