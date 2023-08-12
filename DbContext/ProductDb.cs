
using Microsoft.EntityFrameworkCore;
using ModelsProduct;
using ModelsPay;
namespace ContextPay.ProductDb;

// class ProductDb : DbContext
// {
//     public ProductDb(DbContextOptions<ProductDb> options)
//      : base(options) { }
//     public DbSet<Product> Products { get; set; }
//     public DbSet<Pay> Pays { get; set; }
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Product>()
//             .HasOne(p => p.Pay)
//             .WithMany(p => p.Products)
//             .HasForeignKey(p => p.PayId)
//             .IsRequired();
//     }
// }