using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;

namespace IntegrationTest
{
    public abstract class TestHelper
    {
        public TestHelper()
        {
            httpClient = new WebApplicationFactory<Startup>().CreateClient();

            serviceProvider = new WebApplicationFactory<Startup>().Server.Services;
        }

        private protected readonly HttpClient httpClient;

        private protected readonly IServiceProvider serviceProvider;
    }
}
