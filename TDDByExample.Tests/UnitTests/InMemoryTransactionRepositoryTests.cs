using FluentAssertions;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Repositories;
using Xunit;

namespace TDDByExample.Tests.UnitTests;

public class InMemoryTransactionRepositoryTests
{
    private readonly InMemoryTransactionRepository _repository;

    public InMemoryTransactionRepositoryTests()
    {
        _repository = new InMemoryTransactionRepository();
    }

    [Fact]
    public void Add_GivenValidTransaction_ShouldStoreIt()
    {
        // Arrange
        var transaction = new Transaction(150000, "Salary received");

        // Act
        _repository.Add(transaction);

        // Assert
        var all = _repository.GetAll();
        all.Should().ContainSingle();
        all.First().Amount.Should().Be(150000);
        all.First().Description.Should().Be("Salary received");
    }

    [Fact]
    public void GetAll_GivenMultipleTransactions_ShouldReturnAll()
    {
        // Arrange
        _repository.Add(new Transaction(100000, "Transaction 1"));
        _repository.Add(new Transaction(200000, "Transaction 2"));

        // Act
        var result = _repository.GetAll();

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public void GetById_GivenExistingId_ShouldReturnTransaction()
    {
        // Arrange
        var transaction = new Transaction(50000, "Test");
        _repository.Add(transaction);

        // Act
        var result = _repository.GetById(transaction.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(transaction.Id);
    }

    [Fact]
    public void Clear_ShouldRemoveAllTransactions()
    {
        _repository.Add(new Transaction(100000, "Test"));
        _repository.Clear();

        _repository.GetAll().Should().BeEmpty();
    }
}