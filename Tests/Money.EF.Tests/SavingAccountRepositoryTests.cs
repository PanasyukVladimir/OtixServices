using Money.Domain.Entities.AccountAggregate;
using Money.EF.Repositories;
using Money.EF.Tests.MoneyDBTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money.EF.Tests
{
    [TestFixture]
    public class SavingAccountRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAccountByIdTest(int accountId)
        {
            //Arrange
            var savingAccountRepository = new SavingAccountRepository(_context);
            var expected = new SavingAccount
            {
                Id = 1,
                Name = "SavingAccount1",
                AccountCurrency = AccountCurrencyEnum.UAH,
                Description = "SavingAccount1",
                Balance = 5000,
                GoalSavingBalance = 50000000,
                UserId = 1
            };

            //Act
            SavingAccount result = savingAccountRepository.GetAccountById(accountId);

            //Assert
            Assert.IsInstanceOf(typeof(SavingAccount), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [TestCase(1)]
        public void GetAccountsByUserIdTest(int userId)
        {
            //Arrange
            var savingAccountRepository = new SavingAccountRepository(_context);

            //Act
            var allSavingAccounts = savingAccountRepository.GetAccountsByUserId(userId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<SavingAccount>>(allSavingAccounts);
            Assert.AreEqual(2, allSavingAccounts.Count());
        }

        [Test]
        public void CreateAccountTest()
        {
            //Arrange
            var savingAccountRepository = new SavingAccountRepository(_context);
            var savingAccount = new SavingAccount
            {
                Id = 10,
                Name = "SavingAccount1",
                AccountCurrency = AccountCurrencyEnum.UAH,
                Description = "SavingAccount1",
                Balance = 5000,
                GoalSavingBalance = 500000,
                UserId = 1
            };

            //Act
            savingAccountRepository.CreateAccount(savingAccount);
            var createdSavingAccount = savingAccountRepository.GetAccountById(10);

            //Assert
            Assert.IsInstanceOf(typeof(SavingAccount), createdSavingAccount);
            Assert.AreEqual(savingAccount.Id, createdSavingAccount.Id);
        }

        [Test]
        public void RemoveAccountTest()
        {
            //Arrange
            var savingAccountRepository = new SavingAccountRepository(_context);
            var savingAccount = savingAccountRepository.GetAccountById(2);

            //Act
            savingAccountRepository.RemoveAccount(savingAccount);
            var deletedSavingAccount = savingAccountRepository.GetAccountById(2);

            //Assert
            Assert.IsNull(deletedSavingAccount);
        }

        [Test]
        public void UpdateAccountTest()
        {
            //Arrange
            var savingAccountRepository = new SavingAccountRepository(_context);
            var savingAccount = savingAccountRepository.GetAccountById(1);

            //Act
            savingAccount.Name = "newNameSavingAccount";
            savingAccount.Description = "newDescriptionSavingAccount";
            savingAccountRepository.UpdateAccount(savingAccount);
            var updetedSavingAccount = savingAccountRepository.GetAccountById(1);

            //Assert
            Assert.IsInstanceOf(typeof(SavingAccount), updetedSavingAccount);
            Assert.AreEqual("newNameSavingAccount", updetedSavingAccount.Name);
            Assert.AreEqual("newDescriptionSavingAccount", updetedSavingAccount.Description);
        }
    }
}
