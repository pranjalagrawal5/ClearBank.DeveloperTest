using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    public class FasterPaymentsValidatorTests
    {
        private IValidator _validator;
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _validator = new FasterPaymentsValidator();
            _account = new Account();
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
            _account.Balance = 1000;
        }

        [Test]
        public void IsValid_NullAccount_ReturnsFalse()
        {
            //Act & Assert
            Assert.IsFalse(_validator.IsValid(null, 500));

        }

        [Test]
        public void IsValid_AllowedPaymentSchemesNotFasterPayments_ReturnsFalse()
        {
            //Arrange
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;

            //Act & Assert
            Assert.IsFalse(_validator.IsValid(_account, 500));
        }

        [Test]
        public void IsValid_BalanceAmountLessThanRequestAmount_ReturnsFalse()
        {
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
