using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Services.SuperServices
{
    [TestFixture]
    public class GetSavedMethodTest : TestHelper
    {
        [Test]
        public void GetSaved_NoParametrs_Seccess()
        {
            // Arrange
            var service = serviceProvider.GetRequiredService<SuperService>();

            service.GetType().GetField("value", BindingFlags.NonPublic
                | BindingFlags.Instance).SetValue(service, 2);

            // Act
            var response = service.GetSavedValue();

            // Assert
            Assert.That(response, Is.EqualTo(2));
        }
    }
}
