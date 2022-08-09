using Microsoft.Extensions.DependencyInjection;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Services
{
    [TestFixture]
    public class SuperServiceTest : TestHelper
    {
        [Test]
        public void GetSaved_NoParametrs_Seccess()
        {
            // Arrange
            var service = serviceProvider.GetRequiredService<SuperService>();
            
            // Act
            int response = service.GetSavedValue();

            // Assert
            Assert.That(response.ToString(), Is.EqualTo("4"));
        }

        [Test]
        public void Change_NoParametrs_Seccess()
        {
            // Arrange
            var service = serviceProvider.GetRequiredService<SuperService>();
            service.DoubleSavedValue();

            // Act
            int response = service.GetSavedValue();

            // Assert
            Assert.That(response.ToString(), Is.EqualTo("4"));
        }
    }
}
