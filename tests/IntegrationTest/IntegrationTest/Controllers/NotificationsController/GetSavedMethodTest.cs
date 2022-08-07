using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class GetSavedMethodTest
    {
        private readonly HttpClient _httpClient;

        public GetSavedMethodTest()
        {
            _httpClient = Helper.GetHttpClient();
        }

        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Simple/saved");

            //Act
            var response = await _httpClient.SendAsync(request);
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
