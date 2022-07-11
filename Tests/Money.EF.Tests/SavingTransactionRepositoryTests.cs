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
    public class SavingTransactionRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAllTransactionsByAccountIdTest(int accountId)
        {
            //Arrange
            var savingTransactionRepository = new SavingTransactionRepository(_context);

            //Act
            var allSavingAccountTransactions = savingTransactionRepository.GetAllTransactionsByAccountId(accountId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<SavingAccountTransaction>>(allSavingAccountTransactions);
            Assert.AreEqual(1, allSavingAccountTransactions.Count());
        }

        [TestCase(1)]
        public void GetTransactionByIdTest(int transactionId)
        {
            //Arrange
            var savingTransactionRepository = new SavingTransactionRepository(_context);
            var expected = new SavingAccountTransaction
            {
                Id = 1,
                Amount = 5000,
                Nodes = "SavingAccountTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 1,
                SavingAccountId = 1
            };

            //Act
            SavingAccountTransaction result = savingTransactionRepository.GetTransactionById(transactionId);

            //Assert
            Assert.IsInstanceOf(typeof(SavingAccountTransaction), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateTransactionTest()
        {
            //Arrange
            var savingTransactionRepository = new SavingTransactionRepository(_context);
            var savingAccountTransaction = new SavingAccountTransaction
            {
                Id = 10,
                Amount = 5000,
                Nodes = "SavingAccountTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 1,
                SavingAccountId = 1
            };

            //Act
            savingTransactionRepository.CreateTransaction(savingAccountTransaction);
            var createdSavingAccountTransaction = savingTransactionRepository.GetTransactionById(10);

            //Assert
            Assert.IsInstanceOf(typeof(SavingAccountTransaction), createdSavingAccountTransaction);
            Assert.AreEqual(savingAccountTransaction.Id, createdSavingAccountTransaction.Id);
        }

        [Test]
        public void RemoveTransactionTest()
        {
            //Arrange
            var savingTransactionRepository = new SavingTransactionRepository(_context);
            var savingAccountTransaction = savingTransactionRepository.GetTransactionById(2);

            //Act
            savingTransactionRepository.RemoveTransaction(savingAccountTransaction);
            var deletedSavingAccountTransaction = savingTransactionRepository.GetTransactionById(2);

            //Assert
            Assert.IsNull(deletedSavingAccountTransaction);
        }

        [Test]
        public void UpdateTransactionTest()
        {
            //Arrange
            var savingTransactionRepository = new SavingTransactionRepository(_context);
            var savingAccountTransaction = savingTransactionRepository.GetTransactionById(1);

            //Act
            savingAccountTransaction.Amount = 666;
            savingAccountTransaction.Nodes = "newDescriptionSavingAccountTransaction";
            savingTransactionRepository.UpdateTransaction(savingAccountTransaction);
            var updetedSavingAccountTransaction = savingTransactionRepository.GetTransactionById(1);

            //Assert
            Assert.IsInstanceOf(typeof(SavingAccountTransaction), updetedSavingAccountTransaction);
            Assert.AreEqual(666, updetedSavingAccountTransaction.Amount);
            Assert.AreEqual("newDescriptionSavingAccountTransaction", updetedSavingAccountTransaction.Nodes);
        }
    }
}
