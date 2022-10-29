using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Product;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Core;

namespace Shop.Production.Api.Infrastructure.Services.Contracts
{
    public interface IProductService
    {
        ProductServiceResultCore GetProducts();
        Task<ProductServiceResultCore> SaveProduct(ProductServiceResultAddModel oProductServiceResultModel);
        Task<ProductServiceResultCore> UpdateProduct(ProductServiceResultModifyModel oProductServiceResultModel);
        Task<ProductServiceResultCore> RemoveProduct(int id);
        Task<ProductServiceResultCore> GetProductById(int id);
        Task<bool> ValidateProduct(string productName);
    }
}
