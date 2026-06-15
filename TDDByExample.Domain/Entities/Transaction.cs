namespace TDDByExample.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }

    public Transaction(decimal amount, string description)
    {
        Id = Guid.NewGuid();
        Date = DateTime.UtcNow;

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));

        Amount = amount;
        Description = description;
    }
}