namespace Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

public interface IMessageBuilder
{
    IMessageBuilder SetHeader(string header);

    IMessageBuilder SetBody(string body);

    IMessageBuilder SetRelevance(int relevance);

    Message Build();
}