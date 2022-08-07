using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class ChangeMethodTest
    {
        private readonly HttpClient _httpClient;

        public ChangeMethodTest()
        {
            _httpClient = Helper.GetHttpClient();
        }

        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange
            var requestGet = new HttpRequestMessage(HttpMethod.Get, "/api/Simple/saved");

            //Act
            var responsePut = await _httpClient.PutAsync("/api/Simple/saved", null);
            var responseGet = await _httpClient.SendAsync(requestGet);
            string result = responseGet.Content.ReadAsStringAsync().Result;

            //Assert
            responsePut.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("4"));
        }
    }
}
