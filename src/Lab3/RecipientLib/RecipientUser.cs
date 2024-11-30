namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientLib;

public class RecipientUser
{
    private string Username { get; }

    private readonly int _relevancePriority;

    public RecipientUser(string username, int relevancePriority)
    {
        Username = username;
        _relevancePriority = relevancePriority;
    }

    public void DeliverMessage(string header, string body, int relevance)
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