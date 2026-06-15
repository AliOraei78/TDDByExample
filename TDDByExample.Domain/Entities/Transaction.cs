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
        Amount = amount;
        Date = DateTime.UtcNow;
        Description = description;
    }
}