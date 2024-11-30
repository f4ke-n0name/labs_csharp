namespace Itmo.ObjectOrientedProgramming.Lab2;

public record class User
{
    public Guid UserId { get; }

    public string UserName { get; }

    public User(Guid id, string name)
    {
        UserId = id;
        UserName = name;
    }
}