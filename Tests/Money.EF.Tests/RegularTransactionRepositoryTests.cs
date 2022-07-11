using Money.Domain.Entities.TransactionAggregate;
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
    public class RegularTransactionRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAllTransactionsByAccountIdTest(int accountId)
        {
            //Arrange
            var regularTransactionRepository = new RegularTransactionRepository(_context);

            //Act
            var allDebtAccountTransactions = regularTransactionRepository.GetAllTransactionsByAccountId(accountId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<RegularAccountTransaction>>(allDebtAccountTransactions);
            Assert.AreEqual(1, allDebtAccountTransactions.Count());
        }

        [TestCase(1)]
        public void GetTransactionByIdTest(int transactionId)
        {
            //Arrange
            var regularTransactionRepository = new RegularTransactionRepository(_context);
            var expected = new RegularAccountTransaction
            {
                Id = 1,
                Amount = 500,
                Nodes = "RegularAccountTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 2,
                RegularAccountId = 1
            };

            //Act
            RegularAccountTransaction result = regularTransactionRepository.GetTransactionById(transactionId);

            //Assert
            Assert.IsInstanceOf(typeof(RegularAccountTransaction), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateTransactionTest()
        {
            //Arrange
            var regularTransactionRepository = new RegularTransactionRepository(_context);
            var regularAccountTransaction = new RegularAccountTransaction
            {
                Id = 10,
                Amount = 500,
                Nodes = "RegularAccountTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 2,
                RegularAccountId = 1
            };

            //Act
            regularTransactionRepository.CreateTransaction(regularAccountTransaction);
            var createdRegularAccountTransaction = regularTransactionRepository.GetTransactionById(10);

            //Assert
            Assert.IsInstanceOf(typeof(RegularAccountTransaction), createdRegularAccountTransaction);
            Assert.AreEqual(regularAccountTransaction.Id, createdRegularAccountTransaction.Id);
        }

        [Test]
        public void RemoveTransactionTest()
        {
            //Arrange
            var regularTransactionRepository = new RegularTransactionRepository(_context);
            var regularAccountTransaction = regularTransactionRepository.GetTransactionById(2);

            //Act
            regularTransactionRepository.RemoveTransaction(regularAccountTransaction);
            var deletedRegularAccountTransaction = regularTransactionRepository.GetTransactionById(2);

            //Assert
            Assert.IsNull(deletedRegularAccountTransaction);
        }

        [Test]
        public void UpdateTransactionTest()
        {
            //Arrange
            var regularTransactionRepository = new RegularTransactionRepository(_context);
            var regularAccountTransaction = regularTransactionRepository.GetTransactionById(1);

            //Act
            regularAccountTransaction.Amount = 666;
            regularAccountTransaction.Nodes = "newDescriptionRegularAccountTransaction";
            regularTransactionRepository.UpdateTransaction(regularAccountTransaction);
            var updetedRegularAccountTransaction = regularTransactionRepository.GetTransactionById(1);

            //Assert
            Assert.IsInstanceOf(typeof(RegularAccountTransaction), updetedRegularAccountTransaction);
            Assert.AreEqual(666, updetedRegularAccountTransaction.Amount);
            Assert.AreEqual("newDescriptionRegularAccountTransaction", updetedRegularAccountTransaction.Nodes);
        }
    }
}
