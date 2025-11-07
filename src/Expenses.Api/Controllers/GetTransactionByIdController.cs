using Expenses.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Api.Controllers;

[ApiController]
public class GetTransactionByIdController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    public GetTransactionByIdController(
        ITransactionsService transactionsService
    )
    {
        _transactionsService = transactionsService;
    }

    [HttpGet]
    [Route("api/transactions/{id:guid}")]
    public async Task<IActionResult> GetTransactionById(
        [FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _transactionsService
            .GetById(
                id,
                cancellationToken
            );

        if (transaction is null)
        {
            return NotFound();
        }

        return Ok(transaction);
    }
}
