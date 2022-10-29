using Microsoft.EntityFrameworkCore;
using Shop.Security.Api.Data.Entity;


namespace Shop.Security.Api.Infraestructure.Context
{
    public class SecurityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
       
    }
}
