using System.Threading.Tasks;
using Shop.BackOf.Web.Models;
using Shop.BackOf.Web.Services.Model;

namespace Shop.BackOf.Web.Services.Core
{
    public interface IApiCategoryService
    {
        Task<CategoryResponse> GetCategories(string token);

        Task<CategoryResponse> GetCategoryId(int categoryId, string token);

        Task<CategoryResponse> UpdateCategory(CategoryRequest categoryModel, string token);

        Task<CategoryResponse> Create(CategoryRequest categoryModel, string token);


    }
}
