using NUnit.Framework;

namespace IntegrationTest.Services
{
    [TestFixture]
    public class SuperServiceTest : TestHelper
    {
        [Test, Order(1)]
        public void GetSaved_NoParametrs_Seccess()
        {
            // Arrange

            // Act
            int response = superService.GetSavedValue();

            // Assert
            Assert.That(response.ToString(), Is.EqualTo("2"));
        }

        [Test, Order(2)]
        public void Change_NoParametrs_Seccess()
        {
            // Arrange
            superService.DoubleSavedValue();

            // Act
            int response = superService.GetSavedValue();

            // Assert
            Assert.That(response.ToString(), Is.EqualTo("4"));
        }
    }
}
