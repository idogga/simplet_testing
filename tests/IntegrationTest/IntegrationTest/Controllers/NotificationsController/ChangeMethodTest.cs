using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class ChangeMethodTest
    {
        private readonly HttpClient _httpClient = Helper.GetHttpClient();

        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange

            //Act
            var responsePut = await _httpClient.PutAsync("/api/Simple/saved", null);
            var responseGet = await _httpClient.GetAsync("/api/Simple/saved");
            var result = responseGet.Content.ReadAsStringAsync();

            //Assert
            responsePut.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("4"));
        }
    }
}
