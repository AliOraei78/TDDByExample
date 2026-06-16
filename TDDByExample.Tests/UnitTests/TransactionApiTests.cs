using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using TDDByExample.Domain.Entities;
using Xunit;

namespace TDDByExample.Tests.UnitTests;

public class TransactionApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TransactionApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetBalance_GivenNoTransactions_ShouldReturnZero()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/balance");
        var result = await response.Content.ReadFromJsonAsync<JsonBalanceResponse>();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Balance.Should().Be(0);
    }

    [Fact]
    public async Task AddTransaction_GivenValidData_ShouldReturnCreated()
    {
        var client = _factory.CreateClient();
        var request = new AddTransactionRequest
        {
            Amount = 50000m,
            Description = "API Test",
            Type = TransactionType.Deposit
        };

        var response = await client.PostAsJsonAsync("/transactions", request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task AddTransaction_GivenInvalidAmount_ShouldReturnBadRequest()
    {
        var client = _factory.CreateClient();
        var request = new AddTransactionRequest
        {
            Amount = 500m,
            Description = "Invalid transaction",
            Type = TransactionType.Deposit
        };

        var response = await client.PostAsJsonAsync("/transactions", request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}

// Helper class for JSON deserialization
public class JsonBalanceResponse
{
    public decimal Balance { get; set; }
}