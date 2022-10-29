using Microsoft.AspNetCore.Mvc;
using Shop.Sale.Api.Infraestructure.Service.Contracts;
using Shop.Shared.Core;

namespace Shop.Sale.Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersService _ICustomersService;
        public CustomersController(ICustomersService iCustomersService)
        {
            this._ICustomersService= iCustomersService;
        }

        //Get all the customers
        [HttpGet]
        public ActionResult<ServiceReponse> Get()
        {
            return _ICustomersService.GetCustomers();
        }
    }
}
