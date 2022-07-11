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
    public class RegularAccountRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAccountByIdTest(int accountId)
        {
            //Arrange
            var regularAccountRepository = new RegularAccountRepository(_context);
            var expected = new RegularAccount
            {
                Id = 1,
                Name = "RegularAccount1",
                AccountCurrency = AccountCurrencyEnum.UAH,
                Description = "RegularAccount1",
                Balance = 5000,
                CreditLimit = 0,
                TypeRegularAccount = TypeRegularAccountEnum.Card,
                UserId = 1
            };

            //Act
            RegularAccount result = regularAccountRepository.GetAccountById(accountId);

            //Assert
            Assert.IsInstanceOf(typeof(RegularAccount), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [TestCase(1)]
        public void GetAccountsByUserIdTest(int userId)
        {
            //Arrange
            var regularAccountRepository = new RegularAccountRepository(_context);

            //Act
            var allRegularAccounts = regularAccountRepository.GetAccountsByUserId(userId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<RegularAccount>>(allRegularAccounts);
            Assert.AreEqual(2, allRegularAccounts.Count());
        }

        [Test]
        public void CreateAccountTest()
        {
            //Arrange
            var regularAccountRepository = new RegularAccountRepository(_context);
            var regularAccount = new RegularAccount
            {
                Id = 10,
                Name = "RegularAccount3",
                AccountCurrency = AccountCurrencyEnum.UAH,
                Description = "RegularAccount3",
                Balance = 50000,
                CreditLimit = 0,
                TypeRegularAccount = TypeRegularAccountEnum.Card,
                UserId = 1,
            };

            //Act
            regularAccountRepository.CreateAccount(regularAccount);
            var createdRegularAccount = regularAccountRepository.GetAccountById(10);

            //Assert
            Assert.IsInstanceOf(typeof(RegularAccount), createdRegularAccount);
            Assert.AreEqual(regularAccount.Id, createdRegularAccount.Id);
        }

        [Test]
        public void RemoveAccountTest()
        {
            //Arrange
            var regularAccountRepository = new RegularAccountRepository(_context);
            var regularAccount = regularAccountRepository.GetAccountById(2);

            //Act
            regularAccountRepository.RemoveAccount(regularAccount);
            var deletedRegularAccount = regularAccountRepository.GetAccountById(2);

            //Assert
            Assert.IsNull(deletedRegularAccount);
        }

        [Test]
        public void UpdateAccountTest()
        {
            //Arrange
            var regularAccountRepository = new RegularAccountRepository(_context);
            var regularAccount = regularAccountRepository.GetAccountById(1);

            //Act
            regularAccount.Name = "newNameRegularAccount";
            regularAccount.Description = "newDescriptionRegularAccount";
            regularAccountRepository.UpdateAccount(regularAccount);
            var updetedRegularAccount = regularAccountRepository.GetAccountById(1);

            //Assert
            Assert.IsInstanceOf(typeof(RegularAccount), updetedRegularAccount);
            Assert.AreEqual("newNameRegularAccount", updetedRegularAccount.Name);
            Assert.AreEqual("newDescriptionRegularAccount", updetedRegularAccount.Description);
        }
    }
}
