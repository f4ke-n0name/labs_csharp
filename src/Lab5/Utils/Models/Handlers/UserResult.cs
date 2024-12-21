using Utils.Models.Contracts;

namespace Utils.Models.Handlers;

public class UserResult : IUserResult
{
    public UserResult(long userAccount, short pinCode)
    {
        UserAccount = userAccount;
        PinCode = pinCode;
    }

    public long UserAccount { get; }

    public short PinCode { get; }
}