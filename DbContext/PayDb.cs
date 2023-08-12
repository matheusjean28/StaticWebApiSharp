
using Microsoft.EntityFrameworkCore;
using ModelsPay;
using ModelsProduct;

namespace ContextPay.PayDb;
class PayDb : DbContext
{
    public PayDb(DbContextOptions<PayDb> options)
        : base(options) { }

    public DbSet<Pay> Pays => Set<Pay>();
    public DbSet<Product> Products => Set<Product>();
    
}

