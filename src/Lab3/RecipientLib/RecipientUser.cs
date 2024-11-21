namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientUser
{
    private string Username { get; }

    private readonly uint _relevancePriority;

    public RecipientUser(string username, uint relevancePriority)
    {
        Username = username;
        _relevancePriority = relevancePriority;
    }

    public void DeliverMessage(string header, string body, uint relevance)
    {
        if (relevance > _relevancePriority)
        {
            Console.WriteLine("This is a high priority message!");
        }
        else
        {
            Console.WriteLine("This is a normal priority message.");
        }

        Console.WriteLine($"Message sent to {Username} with header: '{header}' and body: '{body}'");
    }
}