using Expenses.Api.Models;

namespace Expenses.Api.Services;

public interface ITransactionsService
{
    Task<List <Transaction>?> GetAll(CancellationToken cancellationToken = default);
    Task<Transaction?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<Transaction> Add(string type, double amount, string category, CancellationToken cancellationToken = default);
    Task<Transaction?> Update(Guid id, string type, double amount, string category, CancellationToken cancellationToken = default);
    Task<Transaction?> Delete(Guid id, CancellationToken cancellationToken = default);
}
