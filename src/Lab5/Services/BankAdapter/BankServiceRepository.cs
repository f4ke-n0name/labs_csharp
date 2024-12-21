using Utils.Models.Contracts;

namespace Services.BankAdapter;

public class BankServiceRepository : IBankServiceRepository
{
    private readonly IBankServiceRepository _repository;

    public BankServiceRepository(IBankServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IUserAccount> VerifyUser(long bankAccount, short pinCode)
    {
        return await _repository
            .VerifyUser(bankAccount, pinCode)
            .ConfigureAwait(false);
    }

    public async Task<IUserAccount> VerifyAdmin(string systemName, string password)
    {
        return await _repository
            .VerifyAdmin(systemName, password)
            .ConfigureAwait(false);
    }

    public async Task<IUserResult> SaveUser(string firstName, string lastName)
    {
        return await _repository
            .SaveUser(firstName, lastName)
            .ConfigureAwait(false);
    }

    public async Task SaveAdmin(string firstName, string lastName, string systemName, string password)
    {
        await _repository
            .SaveAdmin(firstName, lastName, systemName, password)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmount(long accountId)
    {
        return await _repository
            .GetCashAmount(accountId)
            .ConfigureAwait(false);
    }

    public async Task Withdrawal(long accountId, decimal amount)
    {
        await _repository
            .Withdrawal(accountId, amount)
            .ConfigureAwait(false);
    }

    public async Task Replenishment(long accountId, decimal amount)
    {
        await _repository
            .Replenishment(accountId, amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<ITransaction>> GetTransactionHistory(long accountId)
    {
        IEnumerable<ITransaction> transactionHistory = await _repository
            .GetTransactionHistory(accountId)
            .ConfigureAwait(false);

        return transactionHistory;
    }

    public async Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        return await _repository
            .GetUserIdByBankAccount(bankAccount)
            .ConfigureAwait(false);
    }
}