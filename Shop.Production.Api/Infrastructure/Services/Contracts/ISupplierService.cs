using System.Threading.Tasks;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Supplier;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Core;

namespace Shop.Production.Api.Infrastructure.Services.Contracts
{
    public interface ISupplierService
    {
        Task<SupplierServiceResultCore> SaveSupplier(SupplierServiceResultAddModel oSupplier);
        SupplierServiceResultCore GetSuppliers();
        Task<SupplierServiceResultCore> GetSupplierById(int id);
        Task<SupplierServiceResultCore> UpdateSupplier(SupplierServiceResultModifyModel oSupplier);
        Task<SupplierServiceResultCore> DeleteSupplier(int id);
    }
}
