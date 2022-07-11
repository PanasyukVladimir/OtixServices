using Money.Domain.Entities.UserAggregate;
using Money.EF.Repositories;
using Money.EF.Tests.MoneyDBTests;
using NUnit.Framework;

namespace Money.EF.Tests
{
    [TestFixture]
    public class UserRepositoryTests : MoneyDBTestBase
    {
        [TestCase(3)]
        public void GetUserByIdTest(int userId)
        {
            //Arrange
            var userRepository = new UserRepository(_context);
            var expected = new User {
                Id = 3,
                Login = "user2",
                Password = "user1234",
                Name = "USER2",
                Email = "user2@gmail.com",
                IsEmailConfirmed = true
            };

            //Act
            User result = userRepository.GetUserById(userId);

            //Assert
            Assert.IsAssignableFrom(typeof(User), result);
            Assert.IsInstanceOf(typeof(User), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [TestCase("user2", "user1234")]
        public void GetUserByLoginPasswordTest(string login, string password)
        {
            //Arrange
            var userRepository = new UserRepository(_context);
            var expected = new User
            {
                Id = 3,
                Login = "user2",
                Password = "user1234",
                Name = "USER2",
                Email = "user2@gmail.com",
                IsEmailConfirmed = true
            };

            //Act
            User result = userRepository.GetUserByLoginPassword(login, password);
            
            //Assert
            Assert.IsInstanceOf(typeof(User), result);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [Test]
        public void CreateUserTest()
        {
            //Arrange
            var userRepository = new UserRepository(_context);
            var user = new User
            {
                Id = 4,
                Login = "user4",
                Password = "user41234",
                Name = "USER4",
                Email = "user4@gmail.com",
                IsEmailConfirmed = true
            };

            //Act
            userRepository.CreateUser(user);
            var createdUser = userRepository.GetUserByLoginPassword("user4", "user41234");

            //Assert
            Assert.IsInstanceOf(typeof(User), createdUser);
            Assert.AreEqual(user.Id, createdUser.Id);
        }

        [Test]
        public void RemoveUserTest()
        {
            //Arrange
            var userRepository = new UserRepository(_context);
            var user = userRepository.GetUserById(3);

            //Act
            userRepository.RemoveUser(user);
            var deletedUser = userRepository.GetUserById(3);

            //Assert
            Assert.IsNull(deletedUser);
        }

        [Test]
        public void UpdateUserTest()
        {
            //Arrange
            var userRepository = new UserRepository(_context);
            var user = userRepository.GetUserById(2);

            //Act
            user.Login = "newLoginUSER";
            user.Password = "newPasswordUSER";
            userRepository.UpdateUser(user);
            var updetedUser = userRepository.GetUserByLoginPassword("newLoginUSER", "newPasswordUSER");

            //Assert
            Assert.IsInstanceOf(typeof(User), updetedUser);
            Assert.AreEqual("newLoginUSER", updetedUser.Login);
            Assert.AreEqual("newPasswordUSER", updetedUser.Password);
        }
    }
}
