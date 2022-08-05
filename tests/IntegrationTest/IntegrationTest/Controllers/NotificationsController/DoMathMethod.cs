using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class DoMathMethod
    {
        private readonly HttpClient _httpClient;

        public DoMathMethod()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Test]
        public async Task DoMath_WithCorrectValues_ShouldSesccess()
        {
            //Arrange
            int a = 100;
            int b = 70;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/plus/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content.ReadAsStringAsync().Result, Is.EqualTo($"{a + b}"));
        }

        [Test]
        public async Task DoMath_WithWrong_A_Value_ShouldException()
        {
            //Arrange
            int a = 50;
            int b = 70;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/plus/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(response.Content.ReadAsStringAsync().Result.Contains($"oups,  a value is {a}"));
        }

        [Test]
        public async Task DoMath_WithWrong_B_Value_ShouldException()
        {
            //Arrange
            int a = 100;
            int b = 50;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/plus/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(response.Content.ReadAsStringAsync().Result.Contains($"oups, b value is too be {b}"));
        }
    }
}
