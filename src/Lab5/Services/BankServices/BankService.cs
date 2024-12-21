using Utils.Models.Contracts;

namespace Services.BankServices;

public class BankService : IBankService
{
    private IBankServiceState _state;

    public BankService(IBankServiceState state)
    {
        _state = state;
    }

    public async Task UserLogin(long account, short pinCode)
    {
        _state = await _state
            .UserLogin(account, pinCode)
            .ConfigureAwait(false);
    }

    public async Task AdminLogin(string userName, string password)
    {
        _state = await _state
            .AdminLogin(userName, password)
            .ConfigureAwait(false);
    }

    public async Task Logout()
    {
        _state = await _state
            .Logout()
            .ConfigureAwait(false);
    }

    public async Task<IUserResult> CreateUser(string firstName, string lastName)
    {
        return await _state
            .CreateUser(firstName, lastName)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmount()
    {
        return await _state
            .GetCashAmount()
            .ConfigureAwait(false);
    }

    public async Task Withdrawal(decimal amount)
    {
        await _state
            .Withdrawal(amount)
            .ConfigureAwait(false);
    }

    public async Task Replenishment(decimal amount)
    {
        await _state
            .Replenishment(amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<ITransaction>> Transactions()
    {
        return await _state
            .Transactions()
            .ConfigureAwait(false);
    }

    public async Task CreateAdmin(string firstName, string lastName, string systemName, string password)
    {
        await _state
            .CreateAdmin(firstName, lastName, systemName, password)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmountOf(long userBankAccount)
    {
        long userId = await _state
            .GetUserIdByBankAccount(userBankAccount)
            .ConfigureAwait(false);

        return await _state
            .GetCashAmountOf(userId)
            .ConfigureAwait(false);
    }

    public async Task WithdrawalFrom(long userBankAccount, decimal amount)
    {
        long userId = await _state
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);
        await _state
            .WithdrawalFrom(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task ReplenishmentTo(long userBankAccount, decimal amount)
    {
        long userId = await _state
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);
        await _state
            .ReplenishmentTo(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<ITransaction>> HistoryOf(long userBankAccount)
    {
        long userId = await _state
                .GetUserIdByBankAccount(userBankAccount)
                .ConfigureAwait(false);

        return await _state
            .HistoryOf(userId)
            .ConfigureAwait(false);
    }
}
