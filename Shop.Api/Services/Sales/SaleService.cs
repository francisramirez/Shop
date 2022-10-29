using Microsoft.Extensions.Logging;
using Shop.Api.Models;
using Shop.Api.Models.Request;
using Shop.Api.Models.Response;
using Shop.Api.Services.Sales.Contract;
using System;
using System.Threading.Tasks;

namespace Shop.Api.Services.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ILogger<SaleService> _logger;
        private readonly ShopContext _shopContext;
        public SaleService(ILogger<SaleService> logger, ShopContext shopContext)
        {
            _logger = logger;
            _shopContext = shopContext;
        }

        public async Task<SaleResponse> ProccessSale(SaleRequest saleRequest)
        {
            SaleResponse saleResponse = null;
            try
            {
                var order = new Orders()
                {
                    Custid = saleRequest.Custid,
                    Empid = saleRequest.Empid,
                    Freight = saleRequest.Freight,
                    Orderdate =
                    saleRequest.Orderdate,
                    Requireddate = saleRequest.Requireddate,
                    Shipaddress = saleRequest.Shipaddress,
                    Shipcity = saleRequest.Shipcity,
                    Shipcountry = saleRequest.Shipcountry,
                    Shipname = saleRequest.Shipname,
                    Shippeddate = saleRequest.Shippeddate,
                    Shipperid = saleRequest.Shipperid,
                    Shippostalcode = saleRequest.Shippostalcode,
                    Shipregion = saleRequest.Shipregion,
                };

                _shopContext.Orders.Add(order);

                saleRequest.OrderDetails.ForEach((orderDetails) =>
                {
                    order.OrderDetails.Add(new OrderDetails() 
                    {
                        Orderid = order.Orderid,
                        Discount = orderDetails.Discount, 
                        Productid=orderDetails.Productid, 
                        Qty= orderDetails.Qty, 
                        Unitprice= orderDetails.Unitprice
                    });
                });

                await _shopContext.SaveChangesAsync();

                saleResponse = new SaleResponse() { Success = true, Message = "Sales Proccess.." };

            }
            catch (Exception ex)
            {
                string message= "Error procesing the sale";
               
                _logger.LogError($"{message} {ex.Message}", ex);

                saleResponse = new SaleResponse() { Message= "Error procesing the sale", Success = false };
            }

            return saleResponse;
        }


    }
}
