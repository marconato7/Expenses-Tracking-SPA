using Expenses.Api.Data;
using Expenses.Api.DTOs;
using Expenses.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Api.Controllers;

[ApiController]
public class CreateTransactionController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CreateTransactionController(
        ApplicationDbContext applicationDbContext
    )
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost]
    [Route("api/transactions")]
    public async Task<IActionResult> CreateTransaction(
        [FromBody] CreateTransactionRequest request,
        CancellationToken cancellationToken
    )
    {
        var transaction = new Transaction
        {
            Type = request.Type,
            Amount = request.Amount,
            Category = request.Category,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _applicationDbContext
            .Set<Transaction>()
            .Add(transaction);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return Ok(transaction);
    }
}
