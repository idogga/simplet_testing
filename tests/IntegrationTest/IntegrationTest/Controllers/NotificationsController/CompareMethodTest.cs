using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture, Order(2)]
    public class CompareMethodTest
    {
        [Test]
        public async Task Compare_WithMathingValues_Seccess()
        {
            //Arrange
            int a = 5;
            int b = 5;
            
            //Act
            var response = await Helper._httpClient.GetAsync($"/api/Simple/{a}/is/{b}");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("true"));
        }

        [Test]
        public async Task Compare_WithMismatchedValues_Seccess()
        {
            //Arrange
            int a = 0;
            int b = 10;

            //Act
            var response = await Helper._httpClient.GetAsync($"/api/Simple/{a}/is/{b}");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo("false"));
        }
    }
}
