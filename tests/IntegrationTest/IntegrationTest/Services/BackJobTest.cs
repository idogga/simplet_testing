using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Services
{
    [TestFixture]
    public class BackJobTest : TestHelper
    {
        [Test]
        public void BackJob_NoParametrs_Seccess()
        {
            // Arrange
            var backJob = new BackJob(superService);
            var completed = backJob.StartAsync(CancellationToken.None).IsCompleted;


            // Act
            int response = superService.GetSavedValue();


            // Assert
            Assert.True(completed);
            Assert.That(response.ToString(), Is.EqualTo("4"));
        }
    }
}
