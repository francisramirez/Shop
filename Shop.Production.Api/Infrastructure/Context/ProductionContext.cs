using Microsoft.EntityFrameworkCore;
using Shop.Production.Api.Infrastructure.Data.Entities;

namespace Shop.Production.Api.Infrastructure.Context
{
    public class ProductionContext : DbContext
    {
        //private string _cnnString { get; set; }
        //public ProductionContext(string cnnString)
        //{
        //    this._cnnString = cnnString;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //     options.UseSqlServer(_cnnString);
        }

        public ProductionContext(DbContextOptions<ProductionContext> options)
          : base(options)
        {

            
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
