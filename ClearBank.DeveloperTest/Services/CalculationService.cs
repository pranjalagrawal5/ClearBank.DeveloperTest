namespace ClearBank.DeveloperTest.Services
{
    public class CalculationService : ICalculationService
    {
        /// <summary>
        /// Deducts the requested amount from the account balance
        /// </summary>
        /// <param name="accountBalance">Account balance</param>
        /// <param name="amount">Requested amount</param>
        /// <returns>Remaining amount</returns>
        public decimal GetDeductedBalance(decimal accountBalance, decimal amount)
        {
            return accountBalance - amount;
        }
    }
}
