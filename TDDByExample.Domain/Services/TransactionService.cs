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

    public void AddTransaction(decimal amount, string description)
    {
        var transaction = new Transaction(amount, description);
        _validator.ValidateTransaction(transaction);
        _repository.Add(transaction);
    }
}