using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class GetSavedMethodTest : TestHelper
    {
        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange

            //Act
            var response = await httpClient.GetAsync("/api/Simple/saved");
            var result = await response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
