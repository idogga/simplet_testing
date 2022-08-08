using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture, Order(4)]
    public class ChangeMethodTest
    {
        [Test]
        public async Task GetSaved_NoParametrs_Seccess()
        {
            //Arrange
            var responsePut = await Helper._httpClient.PutAsync("/api/Simple/saved", null);

            //Act
            var responseGet = await Helper._httpClient.GetAsync("/api/Simple/saved");
            var result = responseGet.Content.ReadAsStringAsync();

            //Assert
            responsePut.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("4"));
        }
    }
}
