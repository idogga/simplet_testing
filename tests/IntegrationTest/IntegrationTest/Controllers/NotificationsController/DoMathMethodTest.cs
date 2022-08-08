using System.Net;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class DoMathMethodTest : TestHelper
    {
        [Test]
        public async Task DoMath_WithCorrectValues_Seccess()
        {
            //Arrange
            int a = 100;
            int b = 70;

            //Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = await response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result, Is.EqualTo($"{a + b}"));
        }

        [Test]
        public async Task DoMath_WithWrong_A_Value_Exception()
        {
            //Arrange
            int a = 50;
            int b = 70;

            //Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Contains($"oups,  a value is {a}"));
        }

        [Test]
        public async Task DoMath_WithWrong_B_Value_Exception()
        {
            //Arrange
            int a = 100;
            int b = 50;

            //Act
            var response = await httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Contains($"oups, b value is too be {b}"));
        }
    }
}
