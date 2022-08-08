using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;

namespace IntegrationTest
{
    public class Helper
    {
        public static HttpClient _httpClient = GetHttpClient();

        public static HttpClient GetHttpClient()
        {
            return new WebApplicationFactory<Startup>().CreateClient();
        }
    }
}
