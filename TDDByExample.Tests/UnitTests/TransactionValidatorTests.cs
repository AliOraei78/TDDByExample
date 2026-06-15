using FluentAssertions;
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
}