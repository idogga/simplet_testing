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

            //Act
            var response = await _httpClient.GetAsync("/api/Simple/saved");
            string result = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
