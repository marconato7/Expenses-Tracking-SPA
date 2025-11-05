using Expenses.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("Expenses.db.sqlite");
    // options.UseSqlite("Expenses.db.sqlite");
    // options.UseSqlServer();
});

builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    using var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await applicationDbContext.Database.EnsureDeletedAsync();
    await applicationDbContext.Database.EnsureCreatedAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
