using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class ChangeMethodTest : TestHelper
    {
        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            // Arrange
            await httpClient.PutAsync("/api/Simple/saved", null);

            // Act
            var responseGet = await httpClient.GetAsync("/api/Simple/saved");

            // Assert
            responseGet.EnsureSuccessStatusCode();
            var result = await responseGet.Content.ReadAsStringAsync();
            Assert.That(result, Is.EqualTo("4"));
        }
    }
}
