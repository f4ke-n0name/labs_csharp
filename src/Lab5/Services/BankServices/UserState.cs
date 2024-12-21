using Services.BankAdapter;
using Services.Exceptions;
using Utils.Models.Contracts;

namespace Services.BankServices;

public class UserState : IBankServiceState
{
    private readonly IBankServiceRepository _repository;
    private readonly IUserAccount _accountInfo;

    public UserState(IUserAccount accountInfo, IBankServiceRepository repository)
    {
        _repository = repository;
        _accountInfo = accountInfo;
    }

    public Task<IBankServiceState> UserLogin(long account, short pinCode)
    {
        throw new NotPermitedException();
    }

    public Task<IBankServiceState> AdminLogin(string userName, string password)
    {
        throw new NotPermitedException();
    }

    public Task<IBankServiceState> Logout()
    {
        return new Task<IBankServiceState>(() => new UnauthorizedState(_repository));
    }

    public Task<IUserResult> CreateUser(string firstName, string lastName)
    {
        throw new NotPermitedException();
    }

    public async Task<decimal> GetCashAmount()
    {
        return await _repository
            .GetCashAmount(_accountInfo.AccountId)
            .ConfigureAwait(false);
    }

    public async Task Withdrawal(decimal amount)
    {
        decimal current = await _repository
            .GetCashAmount(_accountInfo.AccountId)
            .ConfigureAwait(false);

        if (current < amount) throw new Exception();

        await _repository
            .Withdrawal(_accountInfo.AccountId, amount)
            .ConfigureAwait(false);
    }

    public async Task Replenishment(decimal amount)
    {
        await _repository
            .Replenishment(_accountInfo.AccountId, amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<ITransaction>> Transactions()
    {
        IEnumerable<ITransaction> history = await _repository
            .GetTransactionHistory(_accountInfo.AccountId)
            .ConfigureAwait(false);

        return history;
    }

    public Task CreateAdmin(string firstName, string lastName, string systemName, string password)
    {
        throw new NotPermitedException();
    }

    public Task<decimal> GetCashAmountOf(long user)
    {
        throw new NotPermitedException();
    }

    public Task<IEnumerable<ITransaction>> HistoryOf(long userId)
    {
        throw new NotPermitedException();
    }

    public Task WithdrawalFrom(long userId, decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task ReplenishmentTo(long userId, decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        throw new NotPermitedException();
    }
}