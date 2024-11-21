using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserLib;

public class User : IUser
{
    public Guid Id { get; }

    public string Name { get; }

    private readonly List<UserMessageStatusInfo> _userMessages = new List<UserMessageStatusInfo>();

    public ReadOnlyCollection<UserMessageStatusInfo> UserMessages => _userMessages.AsReadOnly();

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public void GetMessage(Message message)
    {
        _userMessages.Add(new UserMessageStatusInfo(message, new UserMessageType.Delivered()));
    }

    public UserMessageType MakeMarkedMessage(Message message)
    {
        UserMessageStatusInfo? messageInfo = FindMessage(message);
        if (messageInfo == null) return new UserMessageType.Failed();
        if (messageInfo.Status is UserMessageType.Read)
        {
            return new UserMessageType.Failed();
        }

        var readStatus = new UserMessageType.Read();
        messageInfo.ChangeStatus(readStatus);
        return readStatus;
    }

    public UserMessageType GetStatusOfMessage(Message message)
    {
        UserMessageStatusInfo? messageInfo = FindMessage(message);
        return messageInfo?.Status ?? new UserMessageType.Failed();
    }

    public UserMessageType SendToUser(Message message, IUser user)
    {
        var status = new UserMessageType.Sent();
        _userMessages.Add(new UserMessageStatusInfo(message, status));

        user.GetMessage(message);
        return status;
    }

    public IReadOnlyList<UserMessageStatusInfo> GetStatusOfAllMessages()
    {
        return UserMessages.AsReadOnly();
    }

    public void ChangeToNewStatus(Message message, UserMessageType newStatus)
    {
        UserMessageStatusInfo? messageInfo = FindMessage(message);
        messageInfo?.ChangeStatus(newStatus);
    }

    private UserMessageStatusInfo? FindMessage(Message message)
    {
        return UserMessages.FirstOrDefault(info => info.Message.Equals(message));
    }
}