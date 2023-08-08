using Microsoft.EntityFrameworkCore;
using Models.PayModel;

namespace PayContext.ContextPay;
class PayDb : DbContext
{
    public PayDb(DbContextOptions<PayDb> options)
        : base(options) { }

    public DbSet<Pay> Pays => Set<Pay>();
}