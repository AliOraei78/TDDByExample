using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TDDByExample.Domain.Data;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Repositories;
using TDDByExample.Domain.Services;
using Xunit;

namespace TDDByExample.Tests.IntegrationTests;

public class TransactionIntegrationTests
{
    private readonly AppDbContext _context;
    private readonly TransactionService _service;

    public TransactionIntegrationTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TDDTest_{Guid.NewGuid()}")
            .Options;

        _context = new AppDbContext(options);
        var repository = new EfTransactionRepository(_context);
        var validator = new TransactionValidator();

        _service = new TransactionService(validator, repository);
    }

    [Fact]
    public void AddTransaction_Integration_GivenValidData_ShouldPersistAndUpdateBalance()
    {
        // Arrange
        decimal amount = 50000;
        string desc = "Integration test";

        // Act
        _service.AddTransaction(amount, desc, TransactionType.Deposit);

        // Assert
        var transactions = _service.GetAllTransactions();
        var balance = _service.GetBalance();

        transactions.Should().HaveCount(1);
        balance.Should().Be(50000);
    }

    [Fact]
    public void GetBalance_Integration_GivenMultipleTransactions_ShouldCalculateCorrectly()
    {
        _service.AddTransaction(100000, "Deposit", TransactionType.Deposit);
        _service.AddTransaction(30000, "Withdrawal", TransactionType.Withdrawal);

        decimal balance = _service.GetBalance();

        balance.Should().Be(70000);
    }

    [Fact]
    public void AddTransaction_Integration_GivenInvalidAmount_ShouldThrowException()
    {
        Action act = () => _service.AddTransaction(500, "Invalid");

        act.Should().Throw<ArgumentException>();
    }
}