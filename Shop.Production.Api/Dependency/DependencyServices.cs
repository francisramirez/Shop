using Microsoft.Extensions.DependencyInjection;
using Shop.Production.Api.Infrastructure.Repository.Contracts;
using Shop.Production.Api.Infrastructure.Services.Contracts;
using Shop.Production.Api.Infrastructure.Repository;
using Shop.Production.Api.Infrastructure.Services;
namespace Shop.Production.Api.Dependency
{
    public class DependencyServices
    {
        public static void InitializeApplicationDependencies(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
