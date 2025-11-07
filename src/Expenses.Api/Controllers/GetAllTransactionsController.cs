using Expenses.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Api.Controllers;

[ApiController]
public class GetAllTransactionsController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    public GetAllTransactionsController(
        ITransactionsService transactionsService
    )
    {
        _transactionsService = transactionsService;
    }

    [HttpGet]
    [Route("api/transactions")]
    public async Task<IActionResult> GetAllTransactions(
        CancellationToken cancellationToken
    )
    {
        var transactions = await _transactionsService
            .GetAll(cancellationToken);

        return Ok(transactions);
    }
}
