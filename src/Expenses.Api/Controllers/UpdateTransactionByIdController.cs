using Expenses.Api.DTOs;
using Expenses.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Api.Controllers;

[ApiController]
public class UpdateTransactionByIdController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    public UpdateTransactionByIdController(
        ITransactionsService transactionsService
    )
    {
        _transactionsService = transactionsService;
    }

    [HttpPut]
    [Route("api/transactions/{id:guid}")]
    public async Task<IActionResult> UpdateTransaction(
        [FromRoute] Guid id,
        [FromBody] UpdateTransactionByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _transactionsService
            .Update(
                id,
                request.Type,
                request.Amount,
                request.Category,
                cancellationToken
            );

        if (transaction is null)
        {
            return NotFound();
        }

        return Ok(transaction);
    }
}
