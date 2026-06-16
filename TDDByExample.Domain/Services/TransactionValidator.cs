using TDDByExample.Domain.Entities;

namespace TDDByExample.Domain.Services;

public class TransactionValidator
{
    private const decimal MaxAmount = 100_000_000m;

    public bool ValidateAmount(decimal amount)
    {
        return amount > 0 && amount <= MaxAmount;
    }

    public void ValidateTransaction(Transaction transaction)
    {
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction));

        if (!ValidateAmount(transaction.Amount))
            throw new ArgumentException("Amount must be between 0.01 and 100,000,000", nameof(transaction.Amount));

        if (string.IsNullOrWhiteSpace(transaction.Description))
            throw new ArgumentException("Description cannot be empty", nameof(transaction.Description));
    }

    public void ValidateAmountForTransaction(decimal amount, TransactionType type)
    {
        if (amount <= 1000)
            throw new ArgumentException("Minimum transaction amount is 1000", nameof(amount));

        if (type == TransactionType.Withdrawal && amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive", nameof(amount));

        if (!ValidateAmount(amount))
            throw new ArgumentException("Amount must be between 0.01 and 100,000,000", nameof(amount));
    }
}