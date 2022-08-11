using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Services.SuperServices
{
    [TestFixture]
    public class ChangeMethodTest : TestHelper
    {
        [Test]
        public void Change_NoParametrs_Seccess()
        {
            // Arrange
            var service = serviceProvider.GetRequiredService<SuperService>();

            service.GetType().GetField("value", BindingFlags.NonPublic
                | BindingFlags.Instance).SetValue(service, 2);

            // Act
            service.DoubleSavedValue();

            // Assert
            var response = service.GetSavedValue();
            Assert.That(response, Is.EqualTo(4));
        }
    }
}
