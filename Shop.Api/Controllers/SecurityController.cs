using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Api.Exceptions;
using Shop.Api.Models;
using Shop.Api.Models.Request;
using Shop.Api.Models.Response;
using Shop.Api.Services.Security.Contract;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IUserService _userService;

        public SecurityController(ILogger<SecurityController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequest authRequest)
        {
            if (!this.ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = await _userService.Login(authRequest);

                if (user is null)
                {
                    return BadRequest(new BaseResponse() 
                    { 
                         Message="User or password invalid", Success=false
                    });
                }

                return Ok(new BaseResponse() { Success = true, Data = user });
            }
            catch (SecurityException sEx)
            {
                return BadRequest(new BaseResponse() { Message = sEx.Message, Success = false });
            }

        }
    }
}
