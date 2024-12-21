using Utils.Models.Contracts;

namespace Services.BankServices;

public interface IBankServiceState
{
    public Task<IBankServiceState> UserLogin(long account, short pinCode);

    public Task<IBankServiceState> AdminLogin(string userName, string password);

    public Task<IBankServiceState> Logout();

    public Task<IUserResult> CreateUser(string firstName, string lastName);

    public Task<decimal> GetCashAmount();

    public Task Withdrawal(decimal amount);

    public Task Replenishment(decimal amount);

    public Task<IEnumerable<ITransaction>> Transactions();

    public Task CreateAdmin(string firstName, string lastName, string systemName, string password);

    public Task<decimal> GetCashAmountOf(long user);

    public Task<IEnumerable<ITransaction>> HistoryOf(long userId);

    public Task WithdrawalFrom(long userId, decimal amount);

    public Task ReplenishmentTo(long userId, decimal amount);

    public Task<long> GetUserIdByBankAccount(long bankAccount);
}