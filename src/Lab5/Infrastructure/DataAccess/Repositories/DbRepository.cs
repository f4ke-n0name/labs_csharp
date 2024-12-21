using Utils.Models.Contracts;

namespace Infrastructure.DataAccess.Repositories;

public class DbRepository : IDbRepository
{
    private readonly AccountRepository _accountRepository;
    private readonly UserRepository _userRepository;
    private readonly TransactionRepository _transactionRepository;
    private readonly AdminRepository _adminRepository;

    public DbRepository(AccountRepository accountRepository, UserRepository userRepository, TransactionRepository transactionRepository, AdminRepository adminRepository)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;
        _adminRepository = adminRepository;
    }

    public Task<IUserAccount> VerifyUser(long bankAccount, short pin)
    {
        return _userRepository.VerifyUser(bankAccount, pin);
    }

    public Task<IUserAccount> VerifyAdmin(string password)
    {
        return _adminRepository.VerifyAdmin(password);
    }

    public Task<IUserResult> SaveUser(string firstName, string lastName)
    {
        return _userRepository.SaveUser(firstName, lastName);
    }

    public Task SaveAdmin(string firstName, string lastName, string passwd)
    {
        return _adminRepository.SaveAdmin(firstName, lastName, passwd);
    }

    public Task<decimal> GetCashAmount(long accountId)
    {
        return _transactionRepository.GetCashAmount(accountId);
    }

    public Task Withdrawal(long accountId, decimal amount)
    {
        return _transactionRepository.Withdrawal(accountId, amount);
    }

    public Task Replenishment(long accountId, decimal amount)
    {
        return _transactionRepository.Replenishment(accountId, amount);
    }

    public Task<IEnumerable<ITransaction>> GetTransactionHistory(long accountId)
    {
        return _transactionRepository.GetTransactionHistory(accountId);
    }

    public Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        return _accountRepository.GetUserIdByBankAccount(bankAccount);
    }
}