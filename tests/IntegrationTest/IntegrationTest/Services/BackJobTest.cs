using Microsoft.Extensions.DependencyInjection;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Services
{
    [TestFixture]
    public class BackJobTest : TestHelper
    {
        [Test]
        public async Task BackJob_NoParametrs_Seccess()
        {
            // Arrange
            var service = serviceProvider.GetRequiredService<SuperService>();
            var backJob = new BackJob(service);

            // Act
            await backJob.StartAsync(CancellationToken.None);

            // Assert
            int response = service.GetSavedValue();
            Assert.That(response.ToString(), Is.EqualTo("4"));
        }
    }
}
