using System.Net;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class DoMathMethodTest
    {
        private readonly HttpClient _httpClient;

        public DoMathMethodTest()
        {
            _httpClient = Helper.GetHttpClient();
        }

        [Test]
        public async Task DoMath_WithCorrectValues_Seccess()
        {
            //Arrange
            int a = 100;
            int b = 70;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/plus/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo($"{a + b}"));
        }

        [Test]
        public async Task DoMath_WithWrong_A_Value_Exception()
        {
            //Arrange
            int a = 50;
            int b = 70;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/plus/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Contains($"oups,  a value is {a}"));
        }

        [Test]
        public async Task DoMath_WithWrong_B_Value_Exception()
        {
            //Arrange
            int a = 100;
            int b = 50;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/plus/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Contains($"oups, b value is too be {b}"));
        }
    }
}
