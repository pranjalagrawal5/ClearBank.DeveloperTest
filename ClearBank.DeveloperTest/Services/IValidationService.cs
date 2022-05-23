using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IValidationService
    {
        bool IsValid(PaymentScheme paymentScheme, Account account, decimal amount = 0);
    }
}
