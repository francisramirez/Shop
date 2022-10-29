using Shop.Production.Api.Infrastructure.Services.ServicesResult.Core;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Category;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Product;
using System.Threading.Tasks;

namespace Shop.Production.Api.Infrastructure.Services.Contracts
{
   public interface ICategoryService
    {
        CategoryServiceResultCore GetCategories();
        Task<CategoryServiceResultCore> GetCategoryById(int id);
        Task<CategoryServiceResultCore> SaveCategory(CategoryServiceResultAddModel category);
        Task<CategoryServiceResultCore> UpdateCategory(CategoryServiceResultModifyModel category);
        Task<CategoryServiceResultCore> DeleteCategory(int id);
    }
}
