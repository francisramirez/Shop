
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Api.Models.Request;
using Shop.Api.Models.Response;
using Shop.Api.Services.Sales.Contract;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISaleService _saleService;

        public SaleController(ILogger<SaleController> logger, ISaleService saleService)
        {
            _logger = logger;
            _saleService = saleService;
        }
        [HttpPost("Proccess")]
        public async Task<IActionResult> Add(SaleRequest saleRequest)
        {
            SaleResponse response = null;
            try
            {
                response = await _saleService.ProccessSale(saleRequest);

                if (!response.Success)
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error processing sale", ex);
            }

            return Ok(response);
        }
    }
}
