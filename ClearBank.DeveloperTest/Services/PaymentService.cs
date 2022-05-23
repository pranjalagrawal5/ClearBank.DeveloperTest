using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;
        private readonly IValidationService _validationService;
        private readonly ICalculationService _calculationService;

        public PaymentService(IAccountService accountService, IValidationService validationService, ICalculationService calculationService)
        {
            _accountService = accountService;
            _validationService = validationService;
            _calculationService = calculationService;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountService.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult();
            result.Success = _validationService.IsValid(request.PaymentScheme, account, request.Amount);

            if (result.Success)
            {
                account.Balance = _calculationService.GetDeductedBalance(account.Balance, request.Amount);
                _accountService.UpdateAccount(account);
            }

            return result;
        }
    }
}
