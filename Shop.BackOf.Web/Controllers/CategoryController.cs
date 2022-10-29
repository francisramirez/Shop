using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.BackOf.Web.Models;
using Shop.BackOf.Web.Services.Core;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Shop.BackOf.Web.Controllers
{
    public class CategoryController : BaseController
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly IAuthService _authService;
        private readonly IApiCategoryService _apiCategoryService;
        private readonly IConfiguration _configuration;
        private readonly string token;
         
        public CategoryController(IAuthService authService, 
                                  IApiCategoryService apiCategoryService, 
                                  IConfiguration configuration):base(authService, configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            _authService = authService;
            _apiCategoryService = apiCategoryService;
            _configuration = configuration;
        }

         
        public async Task<IActionResult> Cagegories()
        {
            var result = new CategoryServiceResult();

            string token = "";
                //await base.GetToken();
           
            var categoryResponse = await _apiCategoryService.GetCategories(token);

            if (categoryResponse.Success)
            {
                result = (CategoryServiceResult)categoryResponse.Data;
            }

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = new CategoryDetailResult();

            string token = HttpContext.Session.GetString("Token");

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                using (var response = await httpClient.GetAsync("https://localhost:44391/api/Categories/" + id))
                {
                    if (response.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryDetailResult>(apiResponse);
                    }
                    
                  
                }
            }
            return View(category.data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryList model)
        {
            var category = new CategoryDetailResult();
            
            string token = HttpContext.Session.GetString("Token");

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44391/api/Categories", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<CategoryDetailResult>(apiResponse);
                }
            }
            return RedirectToAction("Cagegories");
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryList model) 
        {
            var category = new CategoryDetailResult();
            
            string token = HttpContext.Session.GetString("Token");

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
               // httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                
                using (var response = await httpClient.PostAsync("https://localhost:44391/api/Categories", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<CategoryDetailResult>(apiResponse);
                }
            }

            return RedirectToAction("Cagegories");
        }

    }
}
