
using Shop.Api.Models.Request;
using Shop.Api.Models.Response;
using System.Threading.Tasks;

namespace Shop.Api.Services.Sales.Contract
{
    public interface ISaleService
    {
        Task<SaleResponse> ProccessSale(SaleRequest saleRequest);
    }
}
