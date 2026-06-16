using TDDByExample.Domain.Entities;
using TDDByExample.Domain.Interfaces;
using TDDByExample.Domain.Repositories;
using TDDByExample.Domain.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddScoped<TransactionValidator>();
builder.Services.AddScoped<ITransactionRepository, InMemoryTransactionRepository>();
builder.Services.AddScoped<TransactionService>();

var app = builder.Build();

// Global Exception Handler
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

        if (exception is ArgumentException)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                Error = exception.Message
            });
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { Error = "An unexpected error occurred." });
        }
    });
});

// Endpoints
app.MapGet("/transactions", (TransactionService service) =>
    Results.Ok(service.GetAllTransactions()));

app.MapPost("/transactions", (AddTransactionRequest request, TransactionService service) =>
{
    service.AddTransaction(request.Amount, request.Description, request.Type);
    return Results.Created("/transactions", new { Message = "Transaction added successfully" });
});

app.MapGet("/balance", (TransactionService service) =>
{
    var balance = service.GetBalance();
    return Results.Ok(new { Balance = balance });
});

app.Run();

public partial class Program { }