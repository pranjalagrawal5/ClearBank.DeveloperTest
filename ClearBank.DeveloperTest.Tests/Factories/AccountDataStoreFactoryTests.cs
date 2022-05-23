using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Tests.Factories
{
    public class AccountDataStoreFactoryTests
    {
        private IAccountDataStoreFactory _accountDataStoreFactory;

        [SetUp]
        public void Setup()
        {
            _accountDataStoreFactory = new AccountDataStoreFactory();
        }

        [Test]
        public void GetAccountDataStore_BackupDataStoreType_ReturnsBackupAccountDataStore()
        {
            //Act
            var dataStore = _accountDataStoreFactory.GetAccountDataStore("Backup");

            //Assert
            Assert.That(dataStore, Is.TypeOf<BackupAccountDataStore>());
        }

        [Test]
        public void GetAccountDataStore_NonBackupDataStoreType_ReturnsAccountDataStore()
        {
            //Act
            var dataStore = _accountDataStoreFactory.GetAccountDataStore("");

            //Assert
            Assert.That(dataStore, Is.TypeOf<AccountDataStore>());
        }
    }
}
