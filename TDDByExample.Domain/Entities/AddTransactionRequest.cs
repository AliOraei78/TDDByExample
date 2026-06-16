namespace TDDByExample.Domain.Entities;

public class AddTransactionRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionType Type { get; set; } = TransactionType.Deposit;
}