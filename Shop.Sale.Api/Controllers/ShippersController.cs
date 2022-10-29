using Microsoft.AspNetCore.Mvc;
using Shop.Sale.Api.Infraestructure.Service.Contracts;
using Shop.Shared.Core;

namespace Shop.Sale.Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ShippersController : Controller
    {
        private readonly IShippersService _IShippersService;
        public ShippersController(IShippersService iShippersService)
        {
            this._IShippersService = iShippersService;
        }
        //Get all Shippers
        [HttpGet]
        public ActionResult<ServiceReponse> Get()
        {
            return _IShippersService.GetShippers();
        }
    }
}
