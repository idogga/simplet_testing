using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class ChangeMethod
    {
        private readonly HttpClient _httpClient;

        public ChangeMethod()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Test]
        public async Task GetSaved_NoParametrs_Sesccess()
        {
            //Arrange
            var requestPut = new HttpRequestMessage(HttpMethod.Put, $"/api/Simple/saved");
            var requestGet = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/saved");

            //Act
            var responsePut = await _httpClient.SendAsync(requestPut);
            var responseGet = await _httpClient.SendAsync(requestGet);

            //Assert
            responsePut.EnsureSuccessStatusCode();
            Assert.That(responseGet.Content.ReadAsStringAsync().Result, Is.EqualTo("4"));
        }
    }
}
