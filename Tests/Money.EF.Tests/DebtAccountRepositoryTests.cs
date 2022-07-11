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
    public class DebtAccountRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAccountByIdTest(int accountId)
        {
            //Arrange
            var debtAccountRepository = new DebtAccountRepository(_context);
            var expected = new DebtAccount
            {
                Id = 1,
                Name = "DebtAccount1",
                AccountCurrency = AccountCurrencyEnum.UAH,
                Description = "DebtAccount1",
                Balance = 500,
                UserId = 1
            };

            //Act
            DebtAccount result = debtAccountRepository.GetAccountById(accountId);

            //Assert
            Assert.IsInstanceOf(typeof(DebtAccount), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [TestCase(1)]
        public void GetAccountsByUserIdTest(int userId)
        {
            //Arrange
            var debtAccountRepository = new DebtAccountRepository(_context);

            //Act
            var allDebtAccounts = debtAccountRepository.GetAccountsByUserId(userId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<DebtAccount>>(allDebtAccounts);
            Assert.AreEqual(2, allDebtAccounts.Count());
        }

        [Test]
        public void CreateAccountTest()
        {
            //Arrange
            var debtAccountRepository = new DebtAccountRepository(_context);
            var debtAccount = new DebtAccount
            {
                Id = 10,
                Name = "newDebtAccount1",
                AccountCurrency = AccountCurrencyEnum.UAH,
                Description = "newDebtAccount1",
                Balance = 500,
                UserId = 1
            };

            //Act
            debtAccountRepository.CreateAccount(debtAccount);
            var createdDebtAccount = debtAccountRepository.GetAccountById(10);

            //Assert
            Assert.IsInstanceOf(typeof(DebtAccount), createdDebtAccount);
            Assert.AreEqual(debtAccount.Id, createdDebtAccount.Id);
        }

        [Test]
        public void RemoveAccountTest()
        {
            //Arrange
            var debtAccountRepository = new DebtAccountRepository(_context);
            var debtAccount = debtAccountRepository.GetAccountById(2);

            //Act
            debtAccountRepository.RemoveAccount(debtAccount);
            var deletedDebtAccount = debtAccountRepository.GetAccountById(2);

            //Assert
            Assert.IsNull(deletedDebtAccount);
        }

        [Test]
        public void UpdateAccountTest()
        {
            //Arrange
            var debtAccountRepository = new DebtAccountRepository(_context);
            var debtAccount = debtAccountRepository.GetAccountById(1);

            //Act
            debtAccount.Name = "newNameDebtAccount";
            debtAccount.Description = "newDescriptionDebtAccount";
            debtAccountRepository.UpdateAccount(debtAccount);
            var updetedDebtAccount = debtAccountRepository.GetAccountById(1);

            //Assert
            Assert.IsInstanceOf(typeof(DebtAccount), updetedDebtAccount);
            Assert.AreEqual("newNameDebtAccount", updetedDebtAccount.Name);
            Assert.AreEqual("newDescriptionDebtAccount", updetedDebtAccount.Description);
        }
    }
}
