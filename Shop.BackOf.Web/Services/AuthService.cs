using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.BackOf.Web.Services.Core;
using Shop.BackOf.Web.Services.Model;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Shop.BackOf.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TokenResponse> CreateToken(CreateTokenRequest createTokenRequest)
        {
            TokenResponse response = new TokenResponse();

            using (var httpClient = _clientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(createTokenRequest), Encoding.UTF8, "application/json");

                var responseHtpp = await httpClient.PostAsync("https://localhost:44320/api/Auth/CreateToken", content);

                string apiResponse = await responseHtpp.Content.ReadAsStringAsync();

                response = JsonConvert.DeserializeObject<TokenResponse>(apiResponse);
            }

            return response;
        }
    }
}
