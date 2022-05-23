using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    public class BacsValidatorTests
    {
        private IValidator _validator;
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _validator = new BacsValidator();
            _account = new Account();
        }

        [Test]
        public void IsValid_NullAccount_ReturnsFalse()
        {
            //Act & Assert
            Assert.IsFalse(_validator.IsValid(null, 0));
            
        }

        [Test]
        public void IsValid_AllowedPaymentSchemesNotBacs_ReturnsFalse()
        {
            //Arrange
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;

            //Act & Assert
            Assert.IsFalse(_validator.IsValid(_account, 0));
        }

        [Test]
        public void IsValid_AllowedPaymentSchemesBacs_ReturnsTrue()
        {
            //Arrange
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs;

            //Act & Assert
            Assert.IsTrue(_validator.IsValid(_account, 0));
        }
    }
}
