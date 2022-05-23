using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    public class ChapsValidatorTests
    {
        private IValidator _validator;
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _validator = new ChapsValidator();
            _account = new Account();
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
            _account.Status = AccountStatus.Live;
        }

        [Test]
        public void IsValid_NullAccount_ReturnsFalse()
        {
            //Act & Assert
            Assert.IsFalse(_validator.IsValid(null, 500));

        }

        [Test]
        public void IsValid_AllowedPaymentSchemesNotChaps_ReturnsFalse()
        {
            //Arrange
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;

            //Act & Assert
            Assert.IsFalse(_validator.IsValid(_account, 500));
        }

        [Test]
        public void IsValid_AccountStatusNotLive_ReturnsFalse()
        {
            //Arrange
            _account.Status = AccountStatus.Disabled;

            //Act & Assert
            Assert.IsFalse(_validator.IsValid(_account, 1500));
        }

        [Test]
        public void IsValid_ValidPymentSchemeAndRequestAmount_ReturnsTrue()
        {
            //Act & Assert
            Assert.IsTrue(_validator.IsValid(_account, 500));
        }
    }
}
