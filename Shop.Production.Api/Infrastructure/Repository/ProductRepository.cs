using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shop.Production.Api.Infrastructure.Context;
using Shop.Production.Api.Infrastructure.Repository.Contracts;
using Shop.Production.Api.Infrastructure.Data.Entities;
using Shop.Shared.Core;

namespace Shop.Production.Api.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductionContext db) : base(db)
        {

        }
        

        public override IEnumerable<Product> FindAll()
        {
  
            return base.FindAll().Where(product => !product.Deleted);

        }
     
    }
}
