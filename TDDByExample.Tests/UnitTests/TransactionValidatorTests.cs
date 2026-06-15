using FluentAssertions;
using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Services;
using Xunit;

namespace TDDByExample.Tests.UnitTests;

public class TransactionValidatorTests
{
    [Fact]
    public void ValidateAmount_Should_Return_False_When_Amount_Is_Zero()
    {
        // Arrange
        var validator = new TransactionValidator();
        decimal amount = 0;

        // Act
        bool result = validator.ValidateAmount(amount);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void ValidateAmount_Should_Return_True_When_Amount_Is_Positive()
    {
        var validator = new TransactionValidator();
        decimal amount = 1000.50m;

        bool result = validator.ValidateAmount(amount);

        result.Should().BeTrue();
    }

    [Fact]
    public void ValidateAmount_Should_Return_False_When_Amount_Is_Negative()
    {
        var validator = new TransactionValidator();
        decimal amount = -500;

        bool result = validator.ValidateAmount(amount);

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.01)]
    [InlineData(-100)]
    public void ValidateAmount_Should_Return_False_For_NonPositive_Amounts(decimal amount)
    {
        var validator = new TransactionValidator();

        bool result = validator.ValidateAmount(amount);

        result.Should().BeFalse();
    }

    [Fact]
public void ValidateAmount_Should_Return_False_When_Amount_Exceeds_MaxLimit()
{
    var validator = new TransactionValidator();
    decimal amount = 100_000_001m;

    bool result = validator.ValidateAmount(amount);

    result.Should().BeFalse();
}

[Fact]
public void ValidateTransaction_Should_Throw_ArgumentNullException_When_Transaction_Is_Null()
{
    var validator = new TransactionValidator();

    Action act = () => validator.ValidateTransaction(null!);

    act.Should().Throw<ArgumentNullException>();
}

[Fact]
public void ValidateTransaction_Should_Throw_ArgumentException_When_Amount_Is_Invalid()
{
    var validator = new TransactionValidator();
    var transaction = new Transaction(0, "Invalid amount test");

    Action act = () => validator.ValidateTransaction(transaction);

    act.Should().Throw<ArgumentException>()
       .WithMessage("*Amount must be between*");
}

[Theory]
[InlineData(0.001)]           // Small positive boundary
[InlineData(100_000_000)]     // Maximum allowed boundary
[InlineData(50_000_000.75)]   // Typical valid value
public void ValidateAmount_Should_Return_True_For_Valid_Boundary_Amounts(decimal amount)
{
    var validator = new TransactionValidator();
    bool result = validator.ValidateAmount(amount);
    result.Should().BeTrue();
}

[Fact]
public void ValidateTransaction_Should_Succeed_For_Valid_Transaction()
{
    var validator = new TransactionValidator();
    var transaction = new Transaction(25000.50m, "Installment laptop purchase");

    Action act = () => validator.ValidateTransaction(transaction);

    act.Should().NotThrow();
}
}