using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NST.Simple.Api;

namespace IntegrationTest
{
    public abstract class TestHelper
    {
        public TestHelper()
        {
            httpClient = new WebApplicationFactory<Startup>().CreateClient();

            IServiceScope serviceScope = new WebApplicationFactory<Startup>().Server
                .Services.CreateScope();

            superService = serviceScope.ServiceProvider.GetRequiredService<SuperService>();
        }

        private protected readonly HttpClient httpClient;

        private protected readonly SuperService superService;
    }
}
