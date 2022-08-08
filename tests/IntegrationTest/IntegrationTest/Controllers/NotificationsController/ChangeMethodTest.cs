using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class ChangeMethodTest : TestHelper
    {
        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange
            var responsePut = await httpClient.PutAsync("/api/Simple/saved", null);

            //Act
            var responseGet = await httpClient.GetAsync("/api/Simple/saved");
            var result = responseGet.Content.ReadAsStringAsync();

            //Assert
            responsePut.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("4"));
        }
    }
}
