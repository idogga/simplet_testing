using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class CompareMethodTest
    {
        private readonly HttpClient _httpClient;

        public CompareMethodTest()
        {
            _httpClient = Helper.GetHttpClient();
        }

        [Test]
        public async Task Compare_WithMathingValues_Seccess()
        {
            //Arrange
            int a = 5;
            int b = 5;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/is/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("true"));
        }

        [Test]
        public async Task Compare_WithMismatchedValues_Seccess()
        {
            //Arrange
            int a = 0;
            int b = 10;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/{a}/is/{b}");

            //Act
            var response = await _httpClient.SendAsync(request);
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("false"));
        }
    }
}
