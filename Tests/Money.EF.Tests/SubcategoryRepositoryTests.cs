using Money.Domain.Entities.CategoryAggregate;
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
    public class SubcategoryRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAllSubcategoriesByCategoryIdTest(int categoryId)
        {
            //Arrange
            var subcategoryRepository = new SubcategoryRepository(_context);

            //Act
            var allSubcategories = subcategoryRepository.GetAllSubcategoriesByCategoryId(categoryId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<Subcategory>>(allSubcategories);
            Assert.AreEqual(3, allSubcategories.Count());
        }

        [TestCase(1)]
        public void GetSubcategoryByIdTest(int subcategoryId)
        {
            //Arrange
            var subcategoryRepository = new SubcategoryRepository(_context);
            var expected = new Subcategory
            {
                Id = 1,
                Name = "Subcategory1",
                Description = "Subcategory1",
                CategoryId = 1
            };

            //Act
            Subcategory result = subcategoryRepository.GetSubcategoryById(subcategoryId);

            //Assert
            Assert.IsInstanceOf(typeof(Subcategory), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateSubcategoryTest()
        {
            //Arrange
            var subcategoryRepository = new SubcategoryRepository(_context);
            var subcategory = new Subcategory
            {
                Id = 10,
                Name = "newSubcategory1",
                Description = "newSubcategory1",
                CategoryId = 1
            };

            //Act
            subcategoryRepository.CreateSubcategory(subcategory);
            var createdDebtAccount = subcategoryRepository.GetSubcategoryById(10);

            //Assert
            Assert.IsInstanceOf(typeof(Subcategory), createdDebtAccount);
            Assert.AreEqual(subcategory.Id, createdDebtAccount.Id);
        }

        [Test]
        public void RemoveSubcategoryTest()
        {
            //Arrange
            var subcategoryRepository = new SubcategoryRepository(_context);
            var subcategory = subcategoryRepository.GetSubcategoryById(3);

            //Act
            subcategoryRepository.RemoveSubcategory(subcategory);
            var deletedSubcategory = subcategoryRepository.GetSubcategoryById(3);

            //Assert
            Assert.IsNull(deletedSubcategory);
        }

        [Test]
        public void UpdateSubcategoryTest()
        {
            //Arrange
            var subcategoryRepository = new SubcategoryRepository(_context);
            var subcategory = subcategoryRepository.GetSubcategoryById(1);

            //Act
            subcategory.Name = "newNameSubcategory";
            subcategory.Description = "newDescriptionSubcategory";
            subcategoryRepository.UpdateSubcategory(subcategory);
            var updetedSubcategory = subcategoryRepository.GetSubcategoryById(1);

            //Assert
            Assert.IsInstanceOf(typeof(Subcategory), updetedSubcategory);
            Assert.AreEqual("newNameSubcategory", updetedSubcategory.Name);
            Assert.AreEqual("newDescriptionSubcategory", updetedSubcategory.Description);
        }
    }
}
