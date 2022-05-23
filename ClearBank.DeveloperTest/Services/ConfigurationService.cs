using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Data store type
        /// </summary>
        public string DataStoreType => ConfigurationManager.AppSettings["DataStoreType"];
    }
}
