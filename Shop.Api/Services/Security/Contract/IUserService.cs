using Shop.Api.Models.Request;
using Shop.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Services.Security.Contract
{
    public interface IUserService
    {
       Task<LoginResponse> Login(AuthRequest authRequest);
    }
}
