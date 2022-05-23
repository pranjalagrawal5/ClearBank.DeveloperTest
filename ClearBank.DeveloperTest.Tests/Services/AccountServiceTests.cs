using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class AccountServiceTests
    {
        private Mock<IConfigurationService> _mockConfigurationService;
        private Mock<IAccountDataStoreFactory> _mockAccountDataStoreFactory;
        private IAccountService _accountService;
        private Mock<IAccountDataStore> _mockAccountDataStore;

        [SetUp]
        public void Setup()
        {
            _mockConfigurationService = new Mock<IConfigurationService>();
            _mockAccountDataStoreFactory = new Mock<IAccountDataStoreFactory>();
            _mockAccountDataStore = new Mock<IAccountDataStore>();

            _accountService = new AccountService(_mockAccountDataStoreFactory.Object, _mockConfigurationService.Object);
        }

        [Test]
        public void GetAccount_GetsAccountFromDataStore()
        {
            //Arrange
            _mockAccountDataStoreFactory.Setup(x=>x.GetAccountDataStore(It.IsAny<string>())).Returns(_mockAccountDataStore.Object);
            _mockAccountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(new Account());

            //Act
            var account = _accountService.GetAccount("111111");

            //Assert
            _mockAccountDataStore.Verify(x => x.GetAccount("111111"), Times.Once);
            Assert.IsNotNull(account);
        }

        [Test]
        public void GetAccount_UpdatesAccountInDataStore()
        {
            //Arrange
            _mockAccountDataStoreFactory.Setup(x => x.GetAccountDataStore(It.IsAny<string>())).Returns(_mockAccountDataStore.Object);
            _mockAccountDataStore.Setup(x => x.UpdateAccount(It.IsAny<Account>())).Verifiable();

            //Act
            _accountService.UpdateAccount(new Account());

            //Assert
            _mockAccountDataStore.Verify(x => x.UpdateAccount(It.IsAny<Account>()), Times.Once);
        }
    }
}
