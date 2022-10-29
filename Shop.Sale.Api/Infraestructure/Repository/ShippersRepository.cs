using Shop.Sale.Api.Data.Entity;
using Shop.Sale.Api.Infraestructure.Context;
using Shop.Sale.Api.Infraestructure.Repository.Contracts;
using Shop.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Sale.Api.Infraestructure.Repository
{
    public class ShippersRepository : BaseRepository<Shippers>, IShippersRepository
    {   
        public ShippersRepository (SaleContext db) : base(db)
        {
        }

        public override IEnumerable<Shippers> FindAll()
        {
            return base.FindAll().Where(Shippers => !Shippers.Deleted);
        }
    }
}
