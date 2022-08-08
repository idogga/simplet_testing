using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;

namespace IntegrationTest
{
    public abstract class TestHelper
    {
        public TestHelper()
        {
            httpClient = new WebApplicationFactory<Startup>().CreateClient();
        }

        private protected readonly HttpClient httpClient;
    }
}
