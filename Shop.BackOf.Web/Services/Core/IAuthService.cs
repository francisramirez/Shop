using System.Threading.Tasks;
using Shop.BackOf.Web.Services.Model;

namespace Shop.BackOf.Web.Services.Core
{
    public interface IAuthService
    {
        Task<TokenResponse> CreateToken(CreateTokenRequest createTokenRequest);
    }
}
