using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientFilter : RecipeintDecorator
{
    private readonly uint _relevancePriority;

    public RecipientFilter(IRecipient currentRecipient, uint relevancePriority) : base(currentRecipient)
    {
        _relevancePriority = relevancePriority;
    }

    public override void SendMessage(Message message)
    {
        if (message.Relevance >= _relevancePriority) base.SendMessage(message);
    }
}