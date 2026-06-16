namespace TDDByExample.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public decimal Balance { get; private set; }
    private readonly List<Transaction> _transactions = new();

    public Account()
    {
        Id = Guid.NewGuid();
        Balance = 0;
    }

    public void AddTransaction(Transaction transaction)
    {
        if (transaction.Type == TransactionType.Withdrawal && Balance < transaction.Amount)
            throw new InvalidOperationException("Insufficient balance for withdrawal");

        _transactions.Add(transaction);

        if (transaction.Type == TransactionType.Deposit)
            Balance += transaction.Amount;
        else
            Balance -= transaction.Amount;
    }

    public IReadOnlyList<Transaction> GetTransactions() => _transactions.AsReadOnly();
    public decimal GetBalance() => Balance;
}