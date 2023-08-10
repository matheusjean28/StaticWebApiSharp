using Microsoft.EntityFrameworkCore;
using ContextPay.PayDb;
using Models.Pay;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PayDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/todoitems", async (PayDb db) =>
    await db.Pays.ToListAsync());

app.MapGet("/todoitems/complete", async (PayDb db) =>
    await db.Pays.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, PayDb db) =>
    await db.Pays.FindAsync(id)
        is Pay pay
            ? Results.Ok(pay)
            : Results.NotFound());

app.MapPost("/todoitems", async (Pay pay, PayDb db) =>
{
    db.Pays.Add(pay);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{pay.Id}", pay);
});



app.Run();