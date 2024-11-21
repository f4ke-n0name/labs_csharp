using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public string Name { get; }

    private readonly List<IRecipient> _recipients;

    public IReadOnlyList<IRecipient> Recipients => _recipients;

    public Topic(string name, IEnumerable<IRecipient> recipients)
    {
        Name = name;
        _recipients = recipients.ToList();
    }

    public void AddMessage(Message message)
    {
        _recipients.ToList().ForEach(recipient => recipient.SendMessage(message));
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }
}