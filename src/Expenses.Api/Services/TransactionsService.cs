using Expenses.Api.Data;
using Expenses.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Api.Services;

public class TransactionsService : ITransactionsService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TransactionsService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Transaction> Add(
        string type,
        double amount,
        string category,
        CancellationToken cancellationToken = default
    )
    {
        var transaction = new Transaction
        {
            Type      = type,
            Amount    = amount,
            Category  = category,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _applicationDbContext
            .Set<Transaction>()
            .Add(transaction);

        await _applicationDbContext
            .SaveChangesAsync(cancellationToken);

        return transaction;
    }

    public async Task<Transaction?> Delete(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var transaction = await _applicationDbContext
            .Set<Transaction>()
            .SingleOrDefaultAsync(
                t => t.Id == id,
                cancellationToken: cancellationToken
            );

        if (transaction is null)
        {
            return null;
        }

        _applicationDbContext
            .Remove(transaction);

        await _applicationDbContext
            .SaveChangesAsync(cancellationToken);

        return transaction;
    }

    public async Task<List<Transaction>?> GetAll(
        CancellationToken cancellationToken = default
    )
    {
        var transactions = await _applicationDbContext
            .Set<Transaction>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return transactions;
    }

    public async Task<Transaction?> GetById(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var transaction = await _applicationDbContext
            .Set<Transaction>()
            .AsNoTracking()
            .SingleOrDefaultAsync(
                t => t.Id == id,
                cancellationToken: cancellationToken
            );

        return transaction;
    }

    public async Task<Transaction?> Update(
        Guid id,
        string type,
        double amount,
        string category,
        CancellationToken cancellationToken = default
    )
    {
        var transaction = await _applicationDbContext
            .Set<Transaction>()
            .SingleOrDefaultAsync(
                t => t.Id == id,
                cancellationToken: cancellationToken
            );

        if (transaction is null)
        {
            return null;
        }

        transaction.Type = type;
        transaction.Amount = amount;
        transaction.Category = category;
        transaction.UpdatedAt = DateTimeOffset.UtcNow;

        _applicationDbContext
            .Set<Transaction>()
            .Update(transaction);

        await _applicationDbContext
            .SaveChangesAsync(cancellationToken);

        return transaction;
    }
}
