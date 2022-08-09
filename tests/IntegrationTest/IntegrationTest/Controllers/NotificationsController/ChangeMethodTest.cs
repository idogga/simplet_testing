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
            var response = await httpClient.GetAsync("/api/Simple/saved");

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.That(result, Is.EqualTo("4"));
        }
    }
}
