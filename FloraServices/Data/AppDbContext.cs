using FloraServices.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace FloraServices.Data
{
   public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<SalesModel> INV_Sale { get; set; }
            public DbSet<SaleDetailModel> INV_SaleDetail { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

            }
        }
}
