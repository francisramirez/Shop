
using System.Net.Http;
using System.Net.Http.Headers;

namespace Shop.BackOf.Web.Services.Core
{
    public static class HttpClientHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void initializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new System.Uri("");
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
