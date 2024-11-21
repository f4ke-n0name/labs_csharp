using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public interface IRecipient
{
    public void SendMessage(Message message);
}