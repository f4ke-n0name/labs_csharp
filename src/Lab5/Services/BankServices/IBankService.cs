using Utils.Models.Contracts;

namespace Services.BankServices;

public interface IBankService
{
    public Task UserLogin(long account, short pinCode);

    public Task AdminLogin(string userName, string password);

    public Task Logout();

    public Task<IUserResult> CreateUser(string firstName, string lastName);

    public Task<decimal> GetCashAmount();

    public Task Withdrawal(decimal amount);

    public Task Replenishment(decimal amount);

    public Task<IEnumerable<ITransaction>> Transactions();

    public Task CreateAdmin(string firstName, string lastName, string systemName, string password);

    public Task WithdrawalFrom(long userBankAccount, decimal amount);

    public Task ReplenishmentTo(long userBankAccount, decimal amount);

    public Task<decimal> GetCashAmountOf(long userBankAccount);

    public Task<IEnumerable<ITransaction>> HistoryOf(long userBankAccount);
}