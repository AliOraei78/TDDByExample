using FluentAssertions;
using Moq;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Interfaces;
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
    public void AddTransaction_GivenValidData_ShouldCallRepositoryAdd()
    {
        // Arrange
        decimal amount = 50000;
        string description = "Monthly salary";

        // Act
        _service.AddTransaction(amount, description);

        // Assert
        _repositoryMock.Verify(r => r.Add(It.IsAny<Transaction>()), Times.Once());
    }

    [Fact]
    public void AddTransaction_GivenInvalidAmount_ShouldThrowArgumentException()
    {
        // Arrange
        decimal amount = -1000;
        string description = "Invalid transaction";

        // Act & Assert
        Action act = () => _service.AddTransaction(amount, description);

        act.Should().Throw<ArgumentException>();
    }
}