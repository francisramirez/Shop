using System.Linq;
using Shop.Security.Api.Infraestructure.Context;
using Shop.Security.Api.Infraestructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shop.Security.Api.Model;
using Shop.Security.Api.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Shop.Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SecurityContext securityContext;
        private readonly IConfiguration configuration;

        public AuthController(SecurityContext securityContext, IConfiguration configuration)
        {
            this.securityContext = securityContext;
            this.configuration = configuration;
        }

        [HttpPost("CreateUser")]

        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {

            this.securityContext.Users.Add(new Data.Entity.User()
            {
                Email = createUserRequest.Email,
                Password = Encript.GetSHA512(createUserRequest.Password),
                Name = createUserRequest.Name
            });

            this.securityContext.SaveChanges();
            return Ok();
        }

        [HttpPost("CreateToken")]
        public IActionResult CreateToken(CreateTokenRequest createTokenRequest)
        {
            // Validar usuario//

            var user = this.securityContext.Users.SingleOrDefault(us => us.Email == createTokenRequest.Email
                                             && us.Password == Encript.GetSHA512(createTokenRequest.Password));
            if (user != null)
            {
                var myToken = GetToken(user);

                return Ok(myToken);
            }
            else
            {
                return BadRequest("User Or Passowrd Invalid.");
            }

        
        }


        private TokenInfo GetToken(User user)
        {

            TokenInfo tokenInfo = new TokenInfo();

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(this.configuration["TokenInfo:SigningKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(JwtRegisteredClaimNames.Email,user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                 }),

                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

          //  HmacSha256Signature
          var token = tokenHandler.CreateToken(tokenDescriptor);

            tokenInfo.Token= tokenHandler.WriteToken(token);
            tokenInfo.Expiration = tokenDescriptor.Expires;

            return tokenInfo;
        }

    }
}
