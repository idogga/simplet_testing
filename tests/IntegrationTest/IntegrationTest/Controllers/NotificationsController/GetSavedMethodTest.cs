using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class GetSavedMethodTest
    {
        private readonly HttpClient _httpClient = Helper.GetHttpClient();

        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange

            //Act
            var response = await _httpClient.GetAsync("/api/Simple/saved");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("2"));
        }
    }
}
