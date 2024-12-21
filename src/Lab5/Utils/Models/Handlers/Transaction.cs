using Utils.Models.Contracts;
using Utils.Models.Enums;

namespace Utils.Models.Handlers;

public class Transaction : ITransaction
{
    public Transaction(OperationType operationType, decimal amount, DateTime dateTime)
    {
        Operation = operationType;
        Amount = amount;
        DateTime = dateTime;
    }

    public OperationType Operation { get; }

    public decimal Amount { get; }

    public DateTime DateTime { get; }
}