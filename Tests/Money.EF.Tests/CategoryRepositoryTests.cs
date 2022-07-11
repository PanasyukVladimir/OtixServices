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
    public class CategoryRepositoryTests : MoneyDBTestBase
    {
        [TestCase(1)]
        public void GetAllCategoriesByUserIdTest(int userId)
        {
            //Arrange
            var categoryRepository = new CategoryRepository(_context);
            
            //Act
            var allCategories = categoryRepository.GetAllCategoriesByUserId(userId);

            //Assert
            Assert.IsInstanceOf<IEnumerable<Category>>(allCategories);
            Assert.AreEqual(3, allCategories.Count());
        }

        [TestCase(1)]
        public void GetCategoryByIdTest(int categoryId)
        {
            //Arrange
            var categoryRepository = new CategoryRepository(_context);
            var expected = new Category
            {
                Id = 1,
                Name = "Category1",
                CategoryCurrency = CategoryCurrencyEnum.UAH,
                Description = "Category1",
                Balance = 0,
                TypeCategory = TypeCategoryEnum.Expenses,
                UserId = 1
            };

            //Act
            Category result = categoryRepository.GetCategoryById(categoryId);

            //Assert
            Assert.IsInstanceOf(typeof(Category), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateCategoryTest()
        {
            //Arrange
            var categoryRepository = new CategoryRepository(_context);
            var category = new Category
            {
                Id = 10,
                Name = "Category1",
                CategoryCurrency = CategoryCurrencyEnum.UAH,
                Description = "Category1",
                Balance = 0,
                TypeCategory = TypeCategoryEnum.Expenses,
                UserId = 1
            };

            //Act
            categoryRepository.CreateCategory(category);
            var createdCategory = categoryRepository.GetCategoryById(10);

            //Assert
            Assert.IsInstanceOf(typeof(Category), createdCategory);
            Assert.AreEqual(category.Id, createdCategory.Id);
        }

        [Test]
        public void RemoveCategoryTest()
        {
            //Arrange
            var categoryRepository = new CategoryRepository(_context);
            var category = categoryRepository.GetCategoryById(3);

            //Act
            categoryRepository.RemoveCategory(category);
            var deletedCategory = categoryRepository.GetCategoryById(3);

            //Assert
            Assert.IsNull(deletedCategory);
        }

        [Test]
        public void UpdateCategoryTest()
        {
            //Arrange
            var categoryRepository = new CategoryRepository(_context);
            var category = categoryRepository.GetCategoryById(1);

            //Act
            category.Name = "newNameCategory";
            category.Description = "newDescriptionCategory";
            categoryRepository.UpdateCategory(category);
            var updetedCategory = categoryRepository.GetCategoryById(1);

            //Assert
            Assert.IsInstanceOf(typeof(Category), updetedCategory);
            Assert.AreEqual("newNameCategory", updetedCategory.Name);
            Assert.AreEqual("newDescriptionCategory", updetedCategory.Description);
        }
    }
}
