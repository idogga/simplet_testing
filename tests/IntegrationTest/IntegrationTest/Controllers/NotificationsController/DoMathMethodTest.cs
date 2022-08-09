using System.Net;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class DoMathMethodTest : TestHelper
    {
        [Test]
        [TestCase("9", "-91")]
        [TestCase("10", "-90")]
        [TestCase("100", "70")]
        [TestCase("101", "71")]
        public async Task DoMath_WithCorrectValues_Seccess(string a, string b)
        {
            // Arrange

            // Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo($"{int.Parse(a) + int.Parse(b)}"));
        }

        [Test]
        [TestCase("11", "70")]
        [TestCase("12", "70")]
        [TestCase("98", "70")]
        [TestCase("99", "70")]
        public async Task DoMath_WithWrong_A_Value_Exception(string a, string b)
        {
            // Arrange

            // Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Contains($"oups,  a value is {a}"));
        }

        [Test]
        [TestCase("100", "-88")]
        [TestCase("100", "-89")]
        [TestCase("100", "68")]
        [TestCase("100", "69")]
        public async Task DoMath_WithWrong_B_Value_Exception(string a, string b)
        {
            // Arrange

            // Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Contains($"oups, b value is too be {b}"));
        }
    }
}
