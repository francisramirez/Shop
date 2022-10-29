using Microsoft.AspNetCore.Mvc;
using System;
using Shop.Production.Api.Infrastructure.Services.Contracts;
using Shop.Shared.Core;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Core;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Product;
using System.Threading.Tasks;
using Shop.Production.Api.Infrastructure.Services.ServicesResult.Models.Supplier;

namespace Shop.Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public readonly ISupplierService _ISupplierService;
        public SuppliersController(ISupplierService iSupplierService)
        {
            this._ISupplierService = iSupplierService;
        }

        [HttpGet]
        public ActionResult<SupplierServiceResultCore> Get()
        {
            return _ISupplierService.GetSuppliers();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ServiceReponse>> GetById(int id)
        {
            return await _ISupplierService.GetSupplierById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceReponse>> Create(SupplierServiceResultAddModel supplierAddModel)
        {
            return await _ISupplierService.SaveSupplier(supplierAddModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ServiceReponse>> Delete(int id)
        {
            return await _ISupplierService.DeleteSupplier(id);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceReponse>> Edit(SupplierServiceResultModifyModel supplierModifyModel)
        {
           
            return Ok(await _ISupplierService.UpdateSupplier(supplierModifyModel));
        }
    }
}