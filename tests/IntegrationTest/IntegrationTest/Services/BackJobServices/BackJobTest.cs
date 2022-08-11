using Microsoft.Extensions.DependencyInjection;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Services.BackJobServices
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
            var response = service.GetSavedValue();
            Assert.That(response, Is.EqualTo(4));
        }
    }
}
