using Microsoft.Extensions.Logging;
using Shop.Api.Models;
using Shop.Api.Models.Request;
using Shop.Api.Models.Response;
using Shop.Api.Services.Security.Contract;
using System;
using System.Security;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Shop.Api.Models.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Shop.Api.Services.Security
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly ShopContext _shopContext;
        private readonly TokenInfo _tokenInfo;

        public UserService(ILogger<UserService> logger, ShopContext shopContext, IOptions<TokenInfo> tokenInfo)
        {
            _logger = logger;
            _shopContext = shopContext;
            _tokenInfo = tokenInfo.Value;
        }
        public async Task<LoginResponse> Login(AuthRequest authRequest)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                var user = await _shopContext.Users.SingleOrDefaultAsync(cd => cd.Email == authRequest.Email
                                                         && cd.Password == Helpers.Encript.GetSHA256(authRequest.Password));

                if (user is null) 
                {
                    response = null;
                    return response;

                }

                response.Email = user.Email;
                response.Token = GetToken(user);

            }
          
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw new SecurityException("Error Authentication....");
            }

            return response;
        }

        private string GetToken(User user) {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(_tokenInfo.SigningKey);
            
            var tokenDescriptor = new SecurityTokenDescriptor() 
            {
                 Subject= new ClaimsIdentity(new Claim[]
                 {
                     //new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                     new Claim(JwtRegisteredClaimNames.Email,user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

                 }), 
                Expires= DateTime.UtcNow.AddHours(1), 
                SigningCredentials  = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        
    }
}
