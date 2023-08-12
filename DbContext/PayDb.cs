
using Microsoft.EntityFrameworkCore;
using Models.Pay;
using Models.Product;

namespace ContextPay.PayDb;
class PayDb : DbContext
{
    public PayDb(DbContextOptions<PayDb> options)
        : base(options) { }

    public DbSet<Pay> Pays => Set<Pay>();
}

class ProductDb : DbContext
{
    public ProductDb(DbContextOptions<ProductDb> options)
     : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Pay> Pays { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Pay)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.PayId);
    }
}