using Utils.Models.Enums;

namespace Utils.Models.Contracts;

public interface ITransaction
{
    public OperationType Operation { get; }

    public decimal Amount { get; }

    public DateTime DateTime { get; }
}