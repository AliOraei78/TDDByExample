using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Interfaces;

namespace TDDByExample.Domain.Repositories;

public class InMemoryTransactionRepository : ITransactionRepository
{
    private readonly List<Transaction> _transactions = new();

    public void Add(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public List<Transaction> GetAll()
    {
        return _transactions.ToList();
    }

    public Transaction? GetById(Guid id)
    {
        return _transactions.FirstOrDefault(t => t.Id == id);
    }

    public void Clear()
    {
        _transactions.Clear();
    }
}