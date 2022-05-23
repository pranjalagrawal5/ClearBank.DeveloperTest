using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataStoreFactory _accountDataStoreFactory;
        private readonly IConfigurationService _configurationService;

        public AccountService(IAccountDataStoreFactory accountDataStoreFactory, IConfigurationService configurationService)
        {
            _accountDataStoreFactory = accountDataStoreFactory;
            _configurationService = configurationService;
        }

        /// <summary>
        /// Gets the account from data store based in account number
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <returns>Account</returns>
        public Account GetAccount(string accountNumber)
        {
            var dataStore = _accountDataStoreFactory.GetAccountDataStore(_configurationService.DataStoreType);
            return dataStore.GetAccount(accountNumber);
        }

        /// <summary>
        /// Updates the account in the data store
        /// </summary>
        /// <param name="account">Account</param>
        public void UpdateAccount(Account account)
        {
            var dataStore = _accountDataStoreFactory.GetAccountDataStore(_configurationService.DataStoreType);
            dataStore.UpdateAccount(account);
        }
    }
}
