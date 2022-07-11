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
    public class DebtTransactionRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAllTransactionsByAccountIdTest(int accountId)
        {
            //Arrange
            var debtTransactionRepository = new DebtTransactionRepository(_context);

            //Act
            var allDebtAccountTransactions = debtTransactionRepository.GetAllTransactionsByAccountId(accountId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<DebtAccountTransaction>>(allDebtAccountTransactions);
            Assert.AreEqual(1, allDebtAccountTransactions.Count());
        }

        [TestCase(1)]
        public void GetTransactionByIdTest(int transactionId)
        {
            //Arrange
            var debtTransactionRepository = new DebtTransactionRepository(_context);
            var expected = new DebtAccountTransaction
            {
                Id = 1,
                Amount = 500,
                Nodes = "DebtAccountTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 1,
                DebtAccountId = 1
            };

            //Act
            DebtAccountTransaction result = debtTransactionRepository.GetTransactionById(transactionId);

            //Assert
            Assert.IsInstanceOf(typeof(DebtAccountTransaction), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateTransactionTest()
        {
            //Arrange
            var debtTransactionRepository = new DebtTransactionRepository(_context);
            var debtAccountTransaction = new DebtAccountTransaction
            {
                Id = 10,
                Amount = 500,
                Nodes = "DebtAccountTransaction1",
                Date = DateTime.Now,
                AccountProvideTransactionId = 1,
                DebtAccountId = 1
            };

            //Act
            debtTransactionRepository.CreateTransaction(debtAccountTransaction);
            var createdDebtAccountTransaction = debtTransactionRepository.GetTransactionById(10);

            //Assert
            Assert.IsInstanceOf(typeof(DebtAccountTransaction), createdDebtAccountTransaction);
            Assert.AreEqual(debtAccountTransaction.Id, createdDebtAccountTransaction.Id);
        }

        [Test]
        public void RemoveTransactionTest()
        {
            //Arrange
            var debtTransactionRepository = new DebtTransactionRepository(_context);
            var debtAccountTransaction = debtTransactionRepository.GetTransactionById(2);

            //Act
            debtTransactionRepository.RemoveTransaction(debtAccountTransaction);
            var deletedDebtAccountTransaction = debtTransactionRepository.GetTransactionById(2);

            //Assert
            Assert.IsNull(deletedDebtAccountTransaction);
        }

        [Test]
        public void UpdateTransactionTest()
        {
            //Arrange
            var debtTransactionRepository = new DebtTransactionRepository(_context);
            var debtAccountTransaction = debtTransactionRepository.GetTransactionById(1);

            //Act
            debtAccountTransaction.Amount = 666;
            debtAccountTransaction.Nodes = "newDescriptionDebtAccountTransaction";
            debtTransactionRepository.UpdateTransaction(debtAccountTransaction);
            var updetedDebtAccountTransaction = debtTransactionRepository.GetTransactionById(1);

            //Assert
            Assert.IsInstanceOf(typeof(DebtAccountTransaction), updetedDebtAccountTransaction);
            Assert.AreEqual(666, updetedDebtAccountTransaction.Amount);
            Assert.AreEqual("newDescriptionDebtAccountTransaction", updetedDebtAccountTransaction.Nodes);
        }
    }
}
