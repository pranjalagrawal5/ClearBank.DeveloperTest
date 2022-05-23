using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class BacsValidator : IValidator
    {
        /// <summary>
        /// Checked if request for BACS payment is valid
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="requestAmount">Request amount</param>
        /// <returns>True/False</returns>
        public bool IsValid(Account account, decimal requestAmount = 0) 
        {
            return account != null && account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs);
        }
    }
}
