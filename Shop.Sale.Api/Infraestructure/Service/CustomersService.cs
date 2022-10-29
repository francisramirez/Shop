using Shop.Sale.Api.Infraestructure.Service.Contracts;
using Shop.Sale.Api.Infraestructure.Repository.Contracts;
using Microsoft.Extensions.Logging;
using Shop.Sale.Api.Data.Entity;
using Microsoft.Extensions.Configuration;
using Shop.Sale.Api.Infraestructure.Service.Core;
using System;
using Shop.Sale.Api.Infraestructure.Service.Models.Customers;
using System.Linq;

namespace Shop.Sale.Api.Infraestructure.Service
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _ICustomersRepository;
        private readonly ILogger<Customers> _ILogger;
        private readonly IConfiguration _IConfiguration;
        public CustomersService(ICustomersRepository _iCustomersRepository,
                                ILogger<Customers> _ILogger,
                                IConfiguration _Configuration)
        {
            this._ICustomersRepository = _iCustomersRepository;
            this._ILogger = _ILogger;
            this._IConfiguration = _Configuration;
        }

        public CustomersServiceResponse GetCustomers()
        {
            CustomersServiceResponse customersResult = new CustomersServiceResponse();

            try
            {
                var query = (from customers in _ICustomersRepository.FindAll()
                             select new CustomersGetModel
                             {
                                 CustomerId = customers.CustId,
                                 CompanyName = customers.CompanyName,
                                 ContactTitle = customers.ContactTitle,
                                 Address = customers.Address,
                                 City = customers.City,
                                 Region = customers.Region,
                                 PostalCode = customers.PostalCode,
                                 Country = customers.Country,
                                 Phone = customers.Phone,
                                 Fax = customers.Fax
                             });

                customersResult.Data = query;
                customersResult.Success = true;
            }
            catch (Exception e)
            {
                _ILogger.LogError($"Error obteniendo los datos. {e.Message}");
                customersResult.Message = "Error obteniendo los datos";
                customersResult.Success = false;
            }
            return customersResult;
        }
    }
}
