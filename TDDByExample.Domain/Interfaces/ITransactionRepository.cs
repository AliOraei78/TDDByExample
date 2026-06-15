using TDDByExample.Domain.Entities;

namespace TDDByExample.Domain.Interfaces;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    List<Transaction> GetAll();
    Transaction? GetById(Guid id);
    void Clear();
}