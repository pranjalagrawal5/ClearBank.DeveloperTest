using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class FasterPaymentsValidator : IValidator
    {
        /// <summary>
        /// Checked if request for Faster payments is valid
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="requestAmount">Request amount</param>
        /// <returns>True/False</returns>
        public virtual bool IsValid(Account account, decimal requestAmount = 0)
        {
            if (account == null || !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                return false;
            }

            return account.Balance >= requestAmount;
        }
    }
}
