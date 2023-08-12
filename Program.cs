using Microsoft.EntityFrameworkCore;
using ContextPay.PayDb;
using Models.Pay;
using Models.Product;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PayDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/v1/paylist", async (PayDb db) =>
    await db.Pays.ToListAsync());

//get prod
app.MapGet("/v1/product", async (ProductDb db) =>
    await db.Products.ToListAsync());

app.MapGet("/v1/paylist/complete", async (PayDb db) =>
    await db.Pays.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/v1/paylist/{id}", async (int id, PayDb db) =>
    await db.Pays.FindAsync(id)
        is Pay pay
            ? Results.Ok(pay)
            : Results.NotFound($"sorry, item {id} not found"));


app.MapPost("/v1/paylist", async (Pay pay, PayDb db) =>
{
    db.Pays.Add(pay);
    await db.SaveChangesAsync();

    return Results.Created($"/v1/paylist/{pay.Id}", pay);
});


// add some produt
app.MapPost("/v1/product", async (Product product, ProductDb db) =>
{   
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/v1/product/{product.Id}", product);
});


app.MapPut("/v1/paylist/{id}", async (int id, Pay pay, PayDb db) =>
{
    var _pay = await db.Pays.FindAsync(id);

    if (_pay is null) return Results.NotFound($"Your Payment was not found!");

    _pay.Name = pay.Name;
    _pay.IsComplete = pay.IsComplete;

    await db.SaveChangesAsync();

    return Results.Ok($"Your Paymente was Updated: {_pay.Name}");
});


app.Run();