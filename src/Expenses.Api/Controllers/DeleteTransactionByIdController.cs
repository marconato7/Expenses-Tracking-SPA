using Expenses.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Api.Controllers;

[ApiController]
public class DeleteTransactionByIdController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    public DeleteTransactionByIdController(
        ITransactionsService transactionsService
    )
    {
        _transactionsService = transactionsService;
    }

    [HttpDelete]
    [Route("api/transactions/{id:guid}")]
    public async Task<IActionResult> DeleteTransactionById(
        [FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        var transaction = await _transactionsService
            .Delete(
                id,
                cancellationToken
            );

        if (transaction is null)
        {
            return NotFound();
        }

        return Ok();
    }
}
