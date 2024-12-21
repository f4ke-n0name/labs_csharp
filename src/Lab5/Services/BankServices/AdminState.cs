using Services.BankAdapter;
using Services.Exceptions;
using Utils.Models.Contracts;

namespace Services.BankServices;

public class AdminState : IBankServiceState
{
    private readonly IBankServiceRepository _repository;

    public AdminState(IBankServiceRepository repository)
    {
        _repository = repository;
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

    public async Task<IUserResult> CreateUser(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length > 20)
            throw new NameLengthException("Incorrect length of first name");

        if (string.IsNullOrEmpty(lastName) || lastName.Length > 20)
            throw new NameLengthException("Incorrect length of last name");

        IUserResult user = await _repository
            .SaveUser(firstName, lastName)
            .ConfigureAwait(false);

        return user;
    }

    public Task<decimal> GetCashAmount()
    {
        throw new NotPermitedException();
    }

    public Task Withdrawal(decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task Replenishment(decimal amount)
    {
        throw new NotPermitedException();
    }

    public Task<IEnumerable<ITransaction>> Transactions()
    {
        throw new NotPermitedException();
    }

    public async Task CreateAdmin(string firstName, string lastName, string systemName, string password)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length > 20)
            throw new NameLengthException("Incorrect length of first name");

        if (string.IsNullOrEmpty(lastName) || lastName.Length > 20)
            throw new NameLengthException("Incorrect length of last name");

        if (string.IsNullOrEmpty(systemName) || systemName.Length > 20)
            throw new NameLengthException("Incorrect length of system name");

        if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 20)
            throw new PasswordBodyException("Incorrect length of password, must be more than 7 and less than 20");

        bool hasUppercase = password.Any(char.IsUpper);
        bool hasLowercase = password.Any(char.IsLower);
        bool hasSpecialChars = password.Any(char.IsPunctuation);

        if (!(hasUppercase && hasLowercase && hasSpecialChars))
            throw new PasswordBodyException("Password must contain lower, upper and special characters");

        await _repository
            .SaveAdmin(firstName, lastName, systemName, password)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmountOf(long user)
    {
        return await _repository
            .GetCashAmount(user)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<ITransaction>> HistoryOf(long userId)
    {
        return await _repository
            .GetTransactionHistory(userId)
            .ConfigureAwait(false);
    }

    public async Task WithdrawalFrom(long userId, decimal amount)
    {
        await _repository
            .Withdrawal(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task ReplenishmentTo(long userId, decimal amount)
    {
        await _repository
            .Replenishment(userId, amount)
            .ConfigureAwait(false);
    }

    public async Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        return await _repository
            .GetUserIdByBankAccount(bankAccount)
            .ConfigureAwait(false);
    }
}