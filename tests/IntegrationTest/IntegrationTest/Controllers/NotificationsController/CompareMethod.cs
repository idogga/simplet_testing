using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class CompareMethod
    {
        private readonly HttpClient _httpClient;

        public CompareMethod()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Test]
        public async Task Compare_WithMathingValues_ShouldSesccess()
        {
            //Arrange
            int a = 5;
            int b = 5;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/is/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content.ReadAsStringAsync().Result, Is.EqualTo("true"));
        }

        [Test]
        public async Task Compare_WithMismatchedValues_ShouldSesccess()
        {
            //Arrange
            int a = 0;
            int b = 10;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/is/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content.ReadAsStringAsync().Result, Is.EqualTo("false"));
        }
    }
}
