using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserLib;

public interface IUser
{
    Guid Id { get; }

    string Name { get; }

    void GetMessage(Message message);

    UserMessageType MakeMarkedMessage(Message message);

    UserMessageType GetStatusOfMessage(Message message);

    UserMessageType SendToUser(Message message, IUser user);

    IReadOnlyList<UserMessageStatusInfo> GetStatusOfAllMessages();

    void ChangeToNewStatus(Message message, UserMessageType newStatus);
}