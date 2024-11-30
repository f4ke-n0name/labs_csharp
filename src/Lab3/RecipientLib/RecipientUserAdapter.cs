using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientUserAdapter : IRecipient
{
    private readonly RecipientUser _recipientUser;

    public RecipientUserAdapter(RecipientUser recipientUser)
    {
        _recipientUser = recipientUser;
    }

    public void SendMessage(Message message)
    {
        _recipientUser.DeliverMessage(message.Header, message.Body, message.Relevance);
    }
}