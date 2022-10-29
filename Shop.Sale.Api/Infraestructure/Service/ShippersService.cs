using Shop.Sale.Api.Infraestructure.Service.Contracts;
using Shop.Sale.Api.Infraestructure.Repository.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Shop.Sale.Api.Data.Entity;
using System.Collections.Generic;
using System;
using Shop.Sale.Api.Infraestructure.Service.Core;
using System.Linq;
using Shop.Sale.Api.Infraestructure.Service.Models.Shipper;

namespace Shop.Sale.Api.Infraestructure.Service
{
    public class ShippersService : IShippersService
    {
        private readonly IShippersRepository _ShipperRepository;
        private readonly ILogger<Shippers> _ILogger;
        private readonly IConfiguration _IConfiguration;
        public ShippersService(IShippersRepository iShipperRepository,
                              ILogger<Shippers> iLogger,
                              IConfiguration iConfiguration)
        {
            this._ShipperRepository = iShipperRepository;
            this._ILogger = iLogger;
            this._IConfiguration = iConfiguration;
        }

        public ShippersServiceResponse GetShippers()
        {
            ShippersServiceResponse shipperServiceResult = new ShippersServiceResponse();

            try
            {
                var query = (from shipper in _ShipperRepository.FindAll()
                             select new ShippersGetModel(){
                             ShipperId = shipper.ShipperId,
                             CompanyName = shipper.CompanyName,
                             Phone = shipper.Phone
                             });
                shipperServiceResult.Data = query;
                shipperServiceResult.Success = true;
            }
            catch (Exception e)
            {
                shipperServiceResult.Message = "Error obteniendo los datos de Shipper";
                shipperServiceResult.Success = false;
                _ILogger.LogError($"Error obteniendo los datos de Shipper{e.Message}");
            }

            return shipperServiceResult;
        }
    }
}
