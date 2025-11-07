using Expenses.Api.DTOs;
using Expenses.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Api.Controllers;

[ApiController]
public class CreateTransactionController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    public CreateTransactionController(
        ITransactionsService transactionsService
    )
    {
        _transactionsService = transactionsService;
    }

    [HttpPost]
    [Route("api/transactions")]
    public async Task<IActionResult> CreateTransaction(
        [FromBody] CreateTransactionRequest request,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _transactionsService
            .Add(
                request.Type,
                request.Amount,
                request.Category,
                cancellationToken
            );

        return Ok(transaction);
    }
}
