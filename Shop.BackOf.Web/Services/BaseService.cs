using Shop.BackOf.Web.Services.Core;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.BackOf.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAuthService _authService;
        public BaseService(IHttpClientFactory clientFactory, IAuthService authService)
        {
            _clientFactory = clientFactory;
            _authService = authService;
        }

        public Task<string> GetToken()
        {
            throw new System.NotImplementedException();
        }
    }
}
