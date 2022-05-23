using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Factories
{
    public class AccountDataStoreFactory : IAccountDataStoreFactory
    {
        /// <summary>
        /// Gets the Account data store based on datastoretype requested
        /// </summary>
        /// <param name="dataStoreType">Data store type</param>
        /// <returns>Account data store</returns>
        public IAccountDataStore GetAccountDataStore(string dataStoreType)
        {
            if(dataStoreType == "Backup")
            {
                return new BackupAccountDataStore();
            }

            return new AccountDataStore();
        }
    }
}
