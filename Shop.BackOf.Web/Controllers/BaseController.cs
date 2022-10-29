using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop.BackOf.Web.Services.Core;
using Shop.BackOf.Web.Services.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shop.BackOf.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public BaseController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
            
        }

        public async Task<string> GetToken()
        {
            string myToken = string.Empty;

            var tokenInfo = new TokenResponse();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Token"))) 
            {
                tokenInfo = await this._authService.CreateToken(new CreateTokenRequest()
                {
                    Email = _configuration["UserInfo:email"],
                    Password = _configuration["UserInfo:pwd"]
                });

                HttpContext.Session.SetString("Token", tokenInfo.Token);

                myToken = HttpContext.Session.GetString("Token");
            }
            else
            {
               return HttpContext.Session.GetString("Token");
            }
            
            return myToken;
        }
    }
}
