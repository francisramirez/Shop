using Microsoft.EntityFrameworkCore;
using Shop.Sale.Api.Data.Entity;


namespace Shop.Sale.Api.Infraestructure.Context
{
    public class SaleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
        }

        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
    }
}
