using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Api.Models;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ShopContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var pwd = _context.Users.FirstOrDefault(cd => cd.Email == "fraramirez@gmail.com").Password;

            var despwd = Helpers.Encript.GetSHA256(pwd);

            var lst = new List<WeatherForecast>() 
            {
                new WeatherForecast(){  Id=1, Nombre="Francis Ramirez"},
                new WeatherForecast(){  Id=2, Nombre="Jose Perez"},
                new WeatherForecast(){  Id=3, Nombre="Juan Garcia"},
            };

            return lst;
             
        }
    }
}
