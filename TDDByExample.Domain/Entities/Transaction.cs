namespace TDDByExample.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public TransactionType Type { get; private set; }

    public Transaction(decimal amount, string description, TransactionType type = TransactionType.Deposit)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));

        if (amount <= 0)
            throw new ArgumentException("Amount must be positive", nameof(amount));

        Id = Guid.NewGuid();
        Amount = amount;
        Date = DateTime.UtcNow;
        Description = description;
        Type = type;
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}