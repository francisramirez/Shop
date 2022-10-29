using Shop.Shared.Core;
using Shop.Sale.Api.Data.Entity;
using Shop.Sale.Api.Infraestructure.Repository.Contracts;
using Shop.Sale.Api.Infraestructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Sale.Api.Infraestructure.Repository
{
    public class CustomersRepository : BaseRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(SaleContext db) : base(db)
        {

        }


        public override IEnumerable<Customers> FindAll()
        {
            return base.FindAll().Where(customer => !customer.Deleted);
        }
    }
}
