using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Interfaces;

namespace TDDByExample.Domain.Services;

public class TransactionService
{
    private readonly TransactionValidator _validator;
    private readonly ITransactionRepository _repository;

    public TransactionService(TransactionValidator validator, ITransactionRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public void AddTransaction(decimal amount, string description, TransactionType type = TransactionType.Deposit)
    {
        _validator.ValidateAddTransaction(amount, description, type);

        var transaction = new Transaction(amount, description, type);
        _repository.Add(transaction);
    }

    public decimal GetBalance()
    {
        var transactions = _repository.GetAll();
        return transactions.Sum(t => t.Type == TransactionType.Deposit ? t.Amount : -t.Amount);
    }

    public List<Transaction> GetAllTransactions() => _repository.GetAll();
}