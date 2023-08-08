using Microsoft.EntityFrameworkCore;
using Models.PayModel;

class PayDb : DbContext
{
    public PayDb(DbContextOptions<PayDb> options)
        : base(options) { }

    public DbSet<Pay> Pays => Set<Pay>();
}