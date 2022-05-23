namespace ClearBank.DeveloperTest.Services
{
    public interface ICalculationService
    {
        decimal GetDeductedBalance(decimal accountBalance, decimal amount);
    }
}
