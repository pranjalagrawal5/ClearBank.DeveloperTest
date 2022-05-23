using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentServiceTests
    {
        private Mock<IAccountService> _mockAccountService;
        private Mock<IValidationService> _mockValidationService;
        private Mock<ICalculationService> _mockCalculationService;
        private PaymentService _paymentService;

        [SetUp]
        public void Setup()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockCalculationService = new Mock<ICalculationService>();
            _mockValidationService = new Mock<IValidationService>();

            _mockAccountService.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(new Account());
            _paymentService = new PaymentService(_mockAccountService.Object, _mockValidationService.Object, _mockCalculationService.Object);
        }

        [Test]
        public void MakePayment_InvalidRequest_ReturnsFalseResult()
        {
            //Arrange
            _mockValidationService.Setup(x => x.IsValid(It.IsAny<PaymentScheme>(), It.IsAny<Account>(), It.IsAny<decimal>())).Returns(false);

            //Act
            var result = _paymentService.MakePayment(new MakePaymentRequest());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void MakePayment_ValidRequest_ReturnsTrueResult()
        {
            //Arrange
            _mockValidationService.Setup(x => x.IsValid(It.IsAny<PaymentScheme>(), It.IsAny<Account>(), It.IsAny<decimal>())).Returns(true);

            //Act
            var result = _paymentService.MakePayment(new MakePaymentRequest());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void MakePayment_ValidRequest_CalculatesBalanceAndUpdatesAccount()
        {
            //Arrange
            _mockValidationService.Setup(x => x.IsValid(It.IsAny<PaymentScheme>(), It.IsAny<Account>(), It.IsAny<decimal>())).Returns(true);

            //Act
            var result = _paymentService.MakePayment(new MakePaymentRequest());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            _mockCalculationService.Verify(x => x.GetDeductedBalance(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
            _mockAccountService.Verify(x => x.UpdateAccount(It.IsAny<Account>()), Times.Once);
        }
    }
}
