using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.BackOf.Web.Models;
using Shop.BackOf.Web.Services.Core;
using Shop.BackOf.Web.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.BackOf.Web.Services
{
    public class ApiCategoryService : IApiCategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAuthService _authService;
        private readonly ILogger<ApiCategoryService> _logger;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;

        public ApiCategoryService(IHttpClientFactory clientFactory,
                                  IAuthService authService, 
                                  ILogger<ApiCategoryService> logger, 
                                  IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _authService = authService;
            _logger = logger;
            _configuration = configuration;
            this.baseUrl = _configuration["ApiConfig:baseUrl"];
        }
        public Task<CategoryResponse> Create(CategoryRequest categoryModel, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryResponse> GetCategories(string token)
        {
            CategoryResponse categoryResponse = new CategoryResponse();

            try
            {
                using (var httpClient = _clientFactory.CreateClient())
                {
                    //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    using (var response = await httpClient.GetAsync($"{this.baseUrl}/api/Categories"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            categoryResponse.Data = JsonConvert.DeserializeObject<CategoryServiceResult>(apiResponse);
                            categoryResponse.Success = true;
                        }
                        else
                        {
                            categoryResponse.Success = false;
                            categoryResponse.Message = "Error obteniendo las categorias.";
                        }
                       
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: ",ex);
                categoryResponse.Success = false;
                categoryResponse.Message = "Error obteniendo las categorias.";
            }

            return categoryResponse;
        }

        public Task<CategoryResponse> GetCategoryId(int categoryId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> UpdateCategory(CategoryRequest categoryModel, string token)
        {
            throw new NotImplementedException();
        }

       
    }
}
