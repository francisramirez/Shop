 using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Shop.Api.Models;
using Shop.Api.Models.Response;
using Shop.Api.Models.Request;
using Shop.Api.Models.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ShopContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            CustomerResponse customerResponse;

            try
            {
                var customers = _context.Customers.Select(cust => new CustumerViewModel(cust))
                                                  .ToList();

                customerResponse = new CustomerResponse()
                {
                    Data = customers,
                    Message = "Custumer Loaded",
                    Success = true
                };

                return Ok(customerResponse);

            }
            catch (Exception ex)
            {
                customerResponse = new CustomerResponse()
                {
                    Message = "Error loading custumers",
                    Success = true
                };

                _logger.LogError($"{customerResponse.Message} {ex.Message}", ex);

                return BadRequest(customerResponse);
            }
        }

        [HttpPost]
        public IActionResult Save(CustumerRequest customerRequest)
        {
            CustomerResponse customerResponse;

            try
            {
                var newCust = new Customers()
                {
                    Address = customerRequest.Address,
                    City = customerRequest.City,
                    Companyname = customerRequest.Companyname,
                    Contactname = customerRequest.Contactname,
                    Contacttitle = customerRequest.Contacttitle,
                    Country = customerRequest.Country,
                    Fax = customerRequest.Fax, 
                    Email= customerRequest.Email,
                    Phone = customerRequest.Phone,
                    Postalcode = customerRequest.Postalcode,
                    Region = customerRequest.Region
                };

                _context.Customers.Add(newCust);

                _context.SaveChanges();

                customerRequest.CustumerId = newCust.Custid;

                customerResponse = new CustomerResponse()
                {
                    Message = "Custumer Saved..",
                    Success = true,
                    Data = customerRequest
                };


                return Ok(customerResponse);

            }
            catch (Exception ex)
            {

                customerResponse = new CustomerResponse()
                {
                    Message = "Error saving custumer info..",
                    Success = false
                };

                _logger.LogError($"Error Saving the customer info {ex.Message}", ex);

                return BadRequest(customerResponse);
            }

        }

        [HttpPut]
        public IActionResult Update(CustumerRequest customerRequest)
        {
            CustomerResponse customerResponse;

            try
            {
                var newCust = new Customers()
                {
                    Address = customerRequest.Address,
                    City = customerRequest.City,
                    Companyname = customerRequest.Companyname,
                    Contactname = customerRequest.Contactname,
                    Contacttitle = customerRequest.Contacttitle,
                    Country = customerRequest.Country,
                    Fax = customerRequest.Fax,
                    Phone = customerRequest.Phone,
                    Postalcode = customerRequest.Postalcode,
                    Region = customerRequest.Region, 
                    Custid= customerRequest.CustumerId, 
                    Email = customerRequest.Email
                };

                _context.Customers.Update(newCust);

                _context.SaveChanges();

                customerRequest.CustumerId = newCust.Custid;

                customerResponse = new CustomerResponse()
                {
                    Message = "Custumer Updated..",
                    Success = true,
                    Data = customerRequest
                };


                return Ok(customerResponse);

            }
            catch (Exception ex)
            {

                customerResponse = new CustomerResponse()
                {
                    Message = "Error updating custumer info..",
                    Success = false
                };

                _logger.LogError($"Error Saving the customer info {ex.Message}", ex);

                return BadRequest(customerResponse);
            }

        }

        [HttpDelete("{custId}")]
        public IActionResult Remove(int custId) 
        {
            CustomerResponse customerResponse;
            try
            {
                var removeCust = this._context.Customers.Find(custId);
                               

                _context.Customers.Remove(removeCust);
                
                _context.SaveChanges();

                customerResponse = new CustomerResponse() { Success=true, Message="Custumer removed.." };

                return Ok(customerResponse);
            }
            catch (Exception ex)
            {
                customerResponse = new CustomerResponse()
                {
                    Message = "Error removing custumer info..",
                    Success = false
                };

                _logger.LogError($"Error removing the customer info {ex.Message}", ex);

                return BadRequest(customerResponse);
            }    
        }

    }
}
