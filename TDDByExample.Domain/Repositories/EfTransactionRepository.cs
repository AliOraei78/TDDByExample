using Microsoft.EntityFrameworkCore;
using TDDByExample.Domain.Data;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Interfaces;

namespace TDDByExample.Domain.Repositories;

public class EfTransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public EfTransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public List<Transaction> GetAll()
    {
        return _context.Transactions.ToList();
    }

    public Transaction? GetById(Guid id)
    {
        return _context.Transactions.FirstOrDefault(t => t.Id == id);
    }

    public void Clear()
    {
        _context.Transactions.RemoveRange(_context.Transactions);
        _context.SaveChanges();
    }
}