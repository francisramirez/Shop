using Shop.Sale.Api.Data.Entity;
using Shop.Sale.Api.Infraestructure.Service.Core;
using System.Collections.Generic;

namespace Shop.Sale.Api.Infraestructure.Service.Contracts
{
    public interface IShippersService
    {
        ShippersServiceResponse GetShippers();
    }
}

