using TDDByExample.Domain.Entities;

namespace TDDByExample.Domain.Services;

public class TransactionValidator
{
    private const decimal MaxAmount = 100_000_000m;
    private const decimal MinAmount = 1000m;

    public bool ValidateAmount(decimal amount)
    {
        return amount >= MinAmount && amount <= MaxAmount;
    }

    public void ValidateTransaction(Transaction transaction)
    {
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction));

        if (!ValidateAmount(transaction.Amount))
            throw new ArgumentException($"Amount must be between {MinAmount} and {MaxAmount}", nameof(transaction.Amount));

        if (string.IsNullOrWhiteSpace(transaction.Description))
            throw new ArgumentException("Description cannot be empty", nameof(transaction.Description));
    }

    public void ValidateAddTransaction(decimal amount, string description, TransactionType type)
    {
        if (amount < MinAmount)
            throw new ArgumentException($"Minimum transaction amount is {MinAmount}", nameof(amount));

        if (amount > MaxAmount)
            throw new ArgumentException($"Maximum transaction amount is {MaxAmount}", nameof(amount));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));
    }
}