namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User
{
    private Guid UserId { get; }

    private string UserName { get; }

    public User(Guid id, string name)
    {
        UserId = id;
        UserName = name;
    }

    public Guid GetUserId()
    {
        return UserId;
    }

    public string GetUserName()
    {
        return UserName;
    }
}