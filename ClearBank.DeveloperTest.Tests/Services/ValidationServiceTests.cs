using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class ValidationServiceTests
    {
        private ValidationService _validationService;
        private Mock<IValidator> _mockBacsValidator;
        private Mock<IValidator> _mockFasterPaymentsValidator;
        private Mock<IValidator> _mockChapsValidator;

        [SetUp]
        public void Setup()
        {
            _mockBacsValidator = new Mock<IValidator>();
            _mockFasterPaymentsValidator = new Mock<IValidator>();
            _mockChapsValidator = new Mock<IValidator>();

            _validationService = new ValidationService
            {
                Validators = new Dictionary<PaymentScheme, IValidator>
                {
                    { PaymentScheme.Bacs, _mockBacsValidator.Object },
                    { PaymentScheme.Chaps, _mockChapsValidator.Object },
                    { PaymentScheme.FasterPayments, _mockFasterPaymentsValidator.Object }
                }
            };
        }

        [Test]
        public void IsValid_BacsPaymentScheme_UsesBacsValidator()
        {
            //Act
            _validationService.IsValid(PaymentScheme.Bacs, new Account(), 0);

            //Assert
            _mockBacsValidator.Verify(x => x.IsValid(It.IsAny<Account>(), It.IsAny<decimal>()), Times.Once);
        }

        [Test]
        public void IsValid_FasterPaymentsPaymentScheme_UsesFasterPaymentsValidator()
        {
            //Act
            _validationService.IsValid(PaymentScheme.FasterPayments, new Account(), 0);

            //Assert
            _mockFasterPaymentsValidator.Verify(x => x.IsValid(It.IsAny<Account>(), It.IsAny<decimal>()), Times.Once);
        }

        [Test]
        public void IsValid_ChapsPaymentScheme_UsesChapsValidator()
        {
            //Act
            _validationService.IsValid(PaymentScheme.Chaps, new Account(), 0);

            //Assert
            _mockChapsValidator.Verify(x => x.IsValid(It.IsAny<Account>(), It.IsAny<decimal>()), Times.Once);
        }
    }
}
