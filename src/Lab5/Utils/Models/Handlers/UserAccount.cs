using Utils.Models.Contracts;
using Utils.Models.Enums;

namespace Utils.Models.Handlers;

public class UserAccount : IUserAccount
{
    public UserAccount(long systemId, UserRole systemRole)
    {
        AccountId = systemId;
        SystemRole = systemRole;
    }

    public long AccountId { get; }

    public UserRole SystemRole { get; }
}