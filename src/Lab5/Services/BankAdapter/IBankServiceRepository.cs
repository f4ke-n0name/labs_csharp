using Utils.Models.Contracts;

namespace Services.BankAdapter;

public interface IBankServiceRepository
{
    Task<IUserAccount> VerifyUser(long bankAccount, short pinCode);

    Task<IUserAccount> VerifyAdmin(string systemName, string password);

    Task<IUserResult> SaveUser(string firstName, string lastName);

    Task SaveAdmin(string firstName, string lastName, string systemName, string password);

    Task<decimal> GetCashAmount(long accountId);

    Task Withdrawal(long accountId, decimal amount);

    Task Replenishment(long accountId, decimal amount);

    Task<IEnumerable<ITransaction>> GetTransactionHistory(long accountId);

    Task<long> GetUserIdByBankAccount(long bankAccount);
}