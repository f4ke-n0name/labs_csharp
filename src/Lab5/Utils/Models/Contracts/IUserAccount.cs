using Utils.Models.Enums;

namespace Utils.Models.Contracts;

public interface IUserAccount
{
    public long AccountId { get; }

    public UserRole SystemRole { get; }
}