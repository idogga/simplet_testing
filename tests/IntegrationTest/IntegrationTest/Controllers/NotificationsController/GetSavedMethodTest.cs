using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture, Order(3)]
    public class GetSavedMethodTest
    {
        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange

            //Act
            var response = await Helper._httpClient.GetAsync("/api/Simple/saved");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("2"));
        }
    }
}
