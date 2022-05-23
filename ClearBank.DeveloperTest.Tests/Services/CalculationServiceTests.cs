using ClearBank.DeveloperTest.Services;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class CalculationServiceTests
    {
        private ICalculationService _calculationService;

        [SetUp]
        public void Setup()
        {
            _calculationService = new CalculationService();
        }

        [TestCase(1000, 500, 500)]
        [TestCase(1000, 1500, -500)]
        public void GetDeductedBalance_ReturnsCorrectAmount(decimal accountBalance, decimal requestAmount, decimal expectedRemainingAmount)
        {
            //Act
            var actualRemainingAmount = _calculationService.GetDeductedBalance(accountBalance, requestAmount);

            //Assert
            Assert.AreEqual(expectedRemainingAmount, actualRemainingAmount);
        }
    }
}
