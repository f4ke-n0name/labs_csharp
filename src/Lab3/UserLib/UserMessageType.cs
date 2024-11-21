namespace Itmo.ObjectOrientedProgramming.Lab3.UserLib;

public record UserMessageType()
{
    public sealed record Sent() : UserMessageType();

    public sealed record Delivered() : UserMessageType();

    public sealed record Read() : UserMessageType();

    public sealed record Failed() : UserMessageType();
}