using System.Reflection;
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

            // Изменение значения поля value на 2 с помощью рефлексии
            service.GetType().GetField("value", BindingFlags.NonPublic 
                | BindingFlags.Instance).SetValue(service, 2);
            
            // Act
            var response = service.GetSavedValue();

            // Assert
            Assert.That(response, Is.EqualTo(2));
        }

        [Test]
        public void Change_NoParametrs_Seccess()
        {
            // Arrange
            var service = serviceProvider.GetRequiredService<SuperService>();

            // Act
            service.DoubleSavedValue();

            // Assert
            var response = service.GetSavedValue();
            Assert.That(response, Is.EqualTo(4));
        }
    }
}
