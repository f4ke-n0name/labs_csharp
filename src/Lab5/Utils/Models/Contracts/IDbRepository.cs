namespace Utils.Models.Contracts;

public interface IDbRepository
{
     Task<IUserAccount> VerifyUser(long bankAccount, short pin);

     Task<IUserAccount> VerifyAdmin(string password);

     Task<IUserResult> SaveUser(string firstName, string lastName);

     Task SaveAdmin(string firstName, string lastName, string passwd);

     Task<decimal> GetCashAmount(long accountId);

     Task Withdrawal(long accountId, decimal amount);

     Task Replenishment(long accountId, decimal amount);

     Task<IEnumerable<ITransaction>> GetTransactionHistory(long accountId);

     Task<long> GetUserIdByBankAccount(long bankAccount);
}