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
    public class DefaultTransactionRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAllTransactionsByAccountIdTest(int accountId)
        {
            //Arrange
            var defaultTransactionRepository = new DefaultTransactionRepository(_context);

            //Act
            var allDefaultAccountTransactions = defaultTransactionRepository.GetAllTransactionsByAccountId(accountId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<DefaultTransaction>>(allDefaultAccountTransactions);
            Assert.AreEqual(2, allDefaultAccountTransactions.Count());
        }

        [TestCase(1)]
        public void GetTransactionByIdTest(int transactionId)
        {
            //Arrange
            var defaultTransactionRepository = new DefaultTransactionRepository(_context);
            var expected = new DefaultTransaction
            {
                Id = 1,
                Amount = 50,
                Nodes = "DefaultTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 1,
                CategoryId = 1
            };

            //Act
            DefaultTransaction result = defaultTransactionRepository.GetTransactionById(transactionId);

            //Assert
            Assert.IsInstanceOf(typeof(DefaultTransaction), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateTransactionTest()
        {
            //Arrange
            var defaultTransactionRepository = new DefaultTransactionRepository(_context);
            var defaultTransaction = new DefaultTransaction
            {
                Id = 10,
                Amount = 50,
                Nodes = "DefaultTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 1,
                CategoryId = 1
            };

            //Act
            defaultTransactionRepository.CreateTransaction(defaultTransaction);
            var createdDefaultTransaction = defaultTransactionRepository.GetTransactionById(10);

            //Assert
            Assert.IsInstanceOf(typeof(DefaultTransaction), createdDefaultTransaction);
            Assert.AreEqual(defaultTransaction.Id, createdDefaultTransaction.Id);
        }

        [Test]
        public void RemoveTransactionTest()
        {
            //Arrange
            var defaultTransactionRepository = new DefaultTransactionRepository(_context);
            var defaultTransaction = defaultTransactionRepository.GetTransactionById(2);

            //Act
            defaultTransactionRepository.RemoveTransaction(defaultTransaction);
            var deletedDefaultTransaction = defaultTransactionRepository.GetTransactionById(2);

            //Assert
            Assert.IsNull(deletedDefaultTransaction);
        }

        [Test]
        public void UpdateTransactionTest()
        {
            //Arrange
            var defaultTransactionRepository = new DefaultTransactionRepository(_context);
            var defaultTransaction = defaultTransactionRepository.GetTransactionById(1);

            //Act
            defaultTransaction.Amount = 666;
            defaultTransaction.Nodes = "newDescriptionDefaultTransaction";
            defaultTransactionRepository.UpdateTransaction(defaultTransaction);
            var updetedDefaultTransaction = defaultTransactionRepository.GetTransactionById(1);

            //Assert
            Assert.IsInstanceOf(typeof(DefaultTransaction), updetedDefaultTransaction);
            Assert.AreEqual(666, updetedDefaultTransaction.Amount);
            Assert.AreEqual("newDescriptionDefaultTransaction", updetedDefaultTransaction.Nodes);
        }
    }
}
