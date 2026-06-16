using FluentAssertions;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Services;
using Xunit;

namespace TDDByExample.Tests.UnitTests;

public class TransactionValidatorTests
{
    private readonly TransactionValidator _validator;

    public TransactionValidatorTests()
    {
        _validator = new TransactionValidator();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.01)]
    [InlineData(-500)]
    public void ValidateAmount_GivenNonPositiveAmount_ShouldReturnFalse(decimal amount)
    {
        // Arrange & Act
        bool result = _validator.ValidateAmount(amount);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(1000)]
    [InlineData(100_000_000)]
    [InlineData(25000.50)]
    public void ValidateAmount_GivenValidAmount_ShouldReturnTrue(decimal amount)
    {
        var validator = new TransactionValidator();
        bool result = validator.ValidateAmount(amount);

        result.Should().BeTrue();
    }

    [Fact]
    public void ValidateAmount_GivenAmountExceedsMaxLimit_ShouldReturnFalse()
    {
        decimal amount = 100_000_001m;

        bool result = _validator.ValidateAmount(amount);

        result.Should().BeFalse();
    }

    [Fact]
    public void ValidateTransaction_GivenNullTransaction_ShouldThrowArgumentNullException()
    {
        Action act = () => _validator.ValidateTransaction(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ValidateTransaction_GivenInvalidAmount_ShouldThrowArgumentException()
    {
        // Arrange
        var validator = new TransactionValidator();
        var invalidTransaction = new Transaction(500, "Test", TransactionType.Deposit);

        // Act
        Action act = () => validator.ValidateTransaction(invalidTransaction);

        // Assert
        act.Should().Throw<ArgumentException>()
           .WithMessage("*Amount must be between 1000 and 100000000*");
    }

    [Fact]
    public void ValidateTransaction_GivenValidTransaction_ShouldNotThrowException()
    {
        var transaction = new Transaction(25000.50m, "Legal purchase");

        Action act = () => _validator.ValidateTransaction(transaction);

        act.Should().NotThrow();
    }
}