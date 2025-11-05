using Expenses.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Api.Data;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<User> Users => Set<User>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}
