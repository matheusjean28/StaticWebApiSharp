using Microsoft.EntityFrameworkCore;
using DbContext.PayDbContext;
using PayContext.ContextPay;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PayDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/todoitems", async (PayDb db) =>
    await db.Pay.ToListAsync());

app.MapGet("/todoitems/complete", async (PayDb db) =>
    await db.Pay.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, PayDb db) =>
    await db.Pay.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/todoitems", async (Todo todo, PayDb db) =>
{
    db.Pay.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, PayDb db) =>
{
    var todo = await db.Pay.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, PayDb db) =>
{
    if (await db.Pay.FindAsync(id) is Todo todo)
    {
        db.Pay.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

app.Run();