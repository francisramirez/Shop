using Shop.Production.Api.Infrastructure.Context;
using Shop.Production.Api.Infrastructure.Data.Entities;
using Shop.Production.Api.Infrastructure.Repository.Contracts;
using Shop.Shared.Core;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Production.Api.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ProductionContext db) : base(db)
        {
        }
        public override IEnumerable<Category> FindAll()
        {
            return base.FindAll().Where(c => c.Deleted == false);

        }
    }
}
