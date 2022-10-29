using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Shop.Security.Api.Infraestructure.Context;
using Shop.Security.Api.Model;

namespace Shop.Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly SecurityContext securityContext;

        public UserController(SecurityContext securityContext)
        {
            this.securityContext = securityContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = this.securityContext.Users.Select(us => new UserListModel(us)).ToArray();

            return Ok(users);
        }
    }
}
