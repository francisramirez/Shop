using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Shared.Contracts;
using Shop.Production.Api.Infrastructure.Data.Entities;
using System.Linq.Expressions;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Core;

namespace Shop.Production.Api.Infrastructure.Repository.Contracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
