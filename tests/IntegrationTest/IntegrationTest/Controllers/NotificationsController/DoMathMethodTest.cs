using System.Net;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture, Order(1)]
    public class DoMathMethodTest
    {
        [Test]
        public async Task DoMath_WithCorrectValues_Seccess()
        {
            //Arrange
            int a = 100;
            int b = 70;

            //Act
            var response = await Helper._httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(result.Result, Is.EqualTo($"{a + b}"));
        }

        [Test]
        public async Task DoMath_WithWrong_A_Value_Exception()
        {
            //Arrange
            int a = 50;
            int b = 70;

            //Act
            var response = await Helper._httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Result.Contains($"oups,  a value is {a}"));
        }

        [Test]
        public async Task DoMath_WithWrong_B_Value_Exception()
        {
            //Arrange
            int a = 100;
            int b = 50;

            //Act
            var response = await Helper._httpClient.GetAsync($"/api/Simple/{a}/plus/{b}");
            var result = response.Content.ReadAsStringAsync();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.IsTrue(result.Result.Contains($"oups, b value is too be {b}"));
        }
    }
}
