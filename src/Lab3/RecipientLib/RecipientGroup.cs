using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientGroup : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public IReadOnlyList<IRecipient> Recipients => _recipients;

    private readonly string _groupName;

    public RecipientGroup(string groupName, IEnumerable<IRecipient> recipients)
    {
        _groupName = groupName;
        _recipients = recipients.ToList();
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }

    public void SendMessage(Message message)
    {
        Console.WriteLine($"Sending message to group '{_groupName}':");
        foreach (IRecipient recipient in _recipients)
        {
            recipient.SendMessage(message);
        }
    }
}