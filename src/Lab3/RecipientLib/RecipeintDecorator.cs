using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public abstract class RecipeintDecorator
{
    private readonly IRecipient _currentRecipient;

    protected RecipeintDecorator(IRecipient currentRecipient)
    {
        _currentRecipient = currentRecipient;
    }

    public virtual void SendMessage(Message message)
    {
        _currentRecipient.SendMessage(message);
    }
}