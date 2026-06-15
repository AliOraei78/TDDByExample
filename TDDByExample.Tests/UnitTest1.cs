using Xunit;
using FluentAssertions;

namespace TDDByExample.Tests.UnitTests;

public class BasicTests
{
    [Fact]
    public void Should_Pass_Basic_Test()
    {
        // Arrange
        int result = 2 + 2;

        // Act & Assert
        result.Should().Be(4);
    }
}