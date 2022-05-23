using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using System.Collections.Generic;

namespace ClearBank.DeveloperTest.Services
{
    public class ValidationService : IValidationService
    {
        public Dictionary<PaymentScheme, IValidator> Validators { get; set; }

        public ValidationService()
        {
            Validators = new Dictionary<PaymentScheme, IValidator>
            {
                { PaymentScheme.Bacs, new BacsValidator() },
                { PaymentScheme.FasterPayments, new FasterPaymentsValidator() },
                { PaymentScheme.Chaps, new ChapsValidator()}
            };
        }

        /// <summary>
        /// Checks if the request is valid
        /// </summary>
        /// <param name="paymentScheme">Payment scheme</param>
        /// <param name="account">Account</param>
        /// <param name="amount">RequestedAmount</param>
        /// <returns>True/False</returns>
        public bool IsValid(PaymentScheme paymentScheme, Account account, decimal amount = 0)
        {
            return Validators[paymentScheme].IsValid(account, amount);
        }
    }
}
