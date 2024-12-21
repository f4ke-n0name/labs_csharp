using Services.BankAdapter;
using Services.Exceptions;
using System.Security.Authentication;
using Utils.Models.Contracts;

namespace Services.BankServices;

public class UnauthorizedState : IBankServiceState
{
    private readonly IBankServiceRepository _repository;

    public UnauthorizedState(IBankServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IBankServiceState> UserLogin(long account, short pinCode)
    {
        try
        {
            IUserAccount accountInfo = await _repository
                .VerifyUser(account, pinCode)
                .ConfigureAwait(false);

            return new UserState(accountInfo, _repository);
        }
        catch (AuthenticationException)
        {
            return this;
        }
    }

    public async Task<IBankServiceState> AdminLogin(string userName, string password)
    {
        try
        {
            IUserAccount accountInfo = await _repository
                .VerifyAdmin(userName, password)
                .ConfigureAwait(false);

            return new AdminState(_repository);
        }
        catch (AuthenticationException)
        {
            return this;
        }
    }

    public Task<IBankServiceState> Logout()
    {
        throw new NotPermitedException();
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

    public Task<IEnumerable<ITransaction>> Transactions(long userId)
    {
        throw new NotPermitedException();
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