using Expenses.Api.Data;
using Expenses.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Api.Controllers;

[ApiController]
public class GetAllTransactionsController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GetAllTransactionsController(
        ApplicationDbContext applicationDbContext
    )
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    [Route("api/transactions")]
    public async Task<IActionResult> GetAllTransactions(
        CancellationToken cancellationToken
    )
    {
        var transactions = await _applicationDbContext
            .Set<Transaction>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Ok(transactions);
    }
}
