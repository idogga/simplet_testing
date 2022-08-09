using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class CompareMethodTest : TestHelper
    {
        [Test]
        public async Task Compare_WithMathingValues_Seccess()
        {
            // Arrange
            string a = "5";
            string b = "5";
            
            // Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/is/{b}");
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("true"));
        }

        [Test]
        public async Task Compare_WithMismatchedValues_Seccess()
        {
            // Arrange
            string a = "0";
            string b = "10";

            // Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/is/{b}");
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo("false"));
        }
    }
}
