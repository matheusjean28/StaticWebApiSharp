
using Microsoft.EntityFrameworkCore;
using Models.Pay;

namespace ContextPay.PayDb;
class PayDb : DbContext
{
    public PayDb(DbContextOptions<PayDb> options)
        : base(options) { }

    public DbSet<Pay> Pays => Set<Pay>();
}