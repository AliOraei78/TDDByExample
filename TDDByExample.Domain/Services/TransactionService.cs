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
        _validator.ValidateAmountForTransaction(amount, type);

        var transaction = new Transaction(amount, description, type);
        _validator.ValidateTransaction(transaction);
        _repository.Add(transaction);
    }

    public decimal GetBalance()
    {
        var transactions = _repository.GetAll();
        decimal balance = 0;

        foreach (var t in transactions)
        {
            if (t.Type == TransactionType.Deposit)
                balance += t.Amount;
            else
                balance -= t.Amount;
        }

        return balance;
    }

    public List<Transaction> GetAllTransactions()
    {
        return _repository.GetAll();
    }
}