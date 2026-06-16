using FluentAssertions;
using Moq;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Interfaces;
using TDDByExample.Domain.Repositories;
using TDDByExample.Domain.Services;
using Xunit;

namespace TDDByExample.Tests.UnitTests;

public class TransactionServiceTests
{
    private readonly Mock<ITransactionRepository> _repositoryMock;
    private readonly TransactionValidator _validator;
    private readonly TransactionService _service;

    public TransactionServiceTests()
    {
        _repositoryMock = new Mock<ITransactionRepository>();
        _validator = new TransactionValidator();
        _service = new TransactionService(_validator, _repositoryMock.Object);
    }

    [Fact]
    public void AddTransaction_GivenValidDeposit_ShouldCallRepositoryAndValidate()
    {
        decimal amount = 50000;
        string desc = "Salary deposit";

        _service.AddTransaction(amount, desc, TransactionType.Deposit);

        _repositoryMock.Verify(r => r.Add(It.IsAny<Transaction>()), Times.Once());
    }

    [Fact]
    public void AddTransaction_GivenAmountBelowMinimum_ShouldThrowException()
    {
        Action act = () => _service.AddTransaction(500, "Below minimum amount");

        act.Should().Throw<ArgumentException>()
           .WithMessage("*Minimum transaction amount is 1000*");
    }

    [Fact]
    public void GetBalance_GivenMixedTransactions_ShouldCalculateCorrectly()
    {
        var repo = new InMemoryTransactionRepository();
        var service = new TransactionService(_validator, repo);

        service.AddTransaction(100000, "Deposit", TransactionType.Deposit);
        service.AddTransaction(30000, "Withdrawal", TransactionType.Withdrawal);

        decimal balance = service.GetBalance();

        balance.Should().Be(70000);
    }

    [Fact]
    public void GetAllTransactions_ShouldReturnAllStoredTransactions()
    {
        var repo = new InMemoryTransactionRepository();
        var service = new TransactionService(_validator, repo);

        service.AddTransaction(50000, "Test 1");
        service.AddTransaction(20000, "Test 2", TransactionType.Withdrawal);

        var result = service.GetAllTransactions();

        result.Should().HaveCount(2);
    }
}