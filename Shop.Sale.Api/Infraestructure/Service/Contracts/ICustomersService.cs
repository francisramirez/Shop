using Shop.Sale.Api.Infraestructure.Service.Core;

namespace Shop.Sale.Api.Infraestructure.Service.Contracts
{
   public interface ICustomersService
    {
        CustomersServiceResponse GetCustomers();
    }
}
