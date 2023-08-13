using Microsoft.EntityFrameworkCore;

namespace DbContextPayDb
{
    public class PayDbContext : DbContext
    {
        public  PayDbContext(DbContextOptions<PayDbContext> options)
            : base(options) { }

        public DbSet<ModelsPay.Pay> Pays { get; set; }
        public DbSet<ModelsProduct.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelsProduct.Product>()
                .HasOne(p => p.Pay)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.PayId);
        }
    }
}
