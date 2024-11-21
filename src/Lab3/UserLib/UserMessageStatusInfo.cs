using Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserLib;

public class UserMessageStatusInfo
{
    public Message Message { get; }

    public UserMessageType Status { get; private set; }

    public UserMessageStatusInfo(Message message, UserMessageType status)
    {
        Message = message;
        Status = status;
    }

    public void ChangeStatus(UserMessageType newStatus)
    {
        Status = newStatus;
    }
}