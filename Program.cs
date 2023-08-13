using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using DbContextPayDb;

using ModelsPay;
using ModelsProduct;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PayDbContext>(opt => opt.UseSqlite("Data Source=paydb.db"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();



app.MapGet("/paylist", async (PayDbContext db) =>
    await db.Pays.ToListAsync());



app.MapPost("/paylist", async (Pay pay, PayDbContext db) =>
{
    db.Pays.Add(pay);
    await db.SaveChangesAsync();

    return Results.Created($"/paylist/{pay.Id}", pay);
});



app.MapPost("/paylist/{id}", async (int id, Product product, PayDbContext db) =>
{
    //checks id exist´s 
    var pay = await db.Pays.FindAsync(id);
    if (pay is null)
    {
        return Results.NotFound($"Payment with ID {id} not found.");
    }

    product.PayId = pay.Id;
    db.Products.Add(product);

    await db.SaveChangesAsync();

    return Results.Created($"/paylist/{product.Id}", product);
});


app.MapGet("/paylist/product/{id}", async (int id, PayDbContext db) =>
{
    var products = await db.Products.ToListAsync();
    if (products is null)
    {
        return Results.NotFound($"Product with ID {id} not found.");
    }
    return Results.Ok(products);

});

app.MapPut("/paylist/{id}", async (int id, Pay pay, PayDbContext db) =>
{
    var _pay = await db.Pays.FindAsync(id);

    if (_pay is null) return Results.NotFound($"Your Payment was not found!");

    _pay.Name = pay.Name;
    _pay.IsComplete = pay.IsComplete;

    await db.SaveChangesAsync();

    return Results.Ok($"Your Paymente was Updated: {_pay.Name}");
});


app.Run();