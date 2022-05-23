using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public interface IValidator
    {
        bool IsValid(Account account, decimal requestAmount = 0);
    }
}
