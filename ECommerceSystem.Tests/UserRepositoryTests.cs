using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceSystem.Repositories;
using ECommerceSystem.Models;
using System.Collections.Generic;

namespace ECommerceSystem.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;

        [TestInitialize]
        public void Setup()
        {
            _userRepository = new UserRepository();
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToRepository()
        {
            // Arrange
            var user = new User(1, "John Doe", "john.doe@example.com");

            // Act
            _userRepository.Add(user);
            var users = _userRepository.GetAll();

            // Assert
            Assert.AreEqual(1, ((List<User>)users).Count);
            Assert.AreEqual("John Doe", ((List<User>)users)[0].Name);
        }

        [TestMethod]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User(1, "John Doe", "john.doe@example.com");
            _userRepository.Add(user);

            // Act
            var result = _userRepository.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John Doe", result.Name);
        }

        [TestMethod]
        public void UpdateUser_ShouldUpdateUserDetails()
        {
            // Arrange
            var user = new User(1, "John Doe", "john.doe@example.com");
            _userRepository.Add(user);

            var updatedUser = new User(1, "John New", "john.new@example.com");

            // Act
            _userRepository.Update(updatedUser);
            var result = _userRepository.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John New", result.Name);
            Assert.AreEqual("john.new@example.com", result.Email);
        }

        [TestMethod]
        public void RemoveUser_ShouldRemoveUserFromRepository()
        {
            // Arrange
            var user = new User(1, "John Doe", "john.doe@example.com");
            _userRepository.Add(user);

            // Act
            _userRepository.Remove(1);
            var result = _userRepository.GetById(1);

            // Assert
            Assert.IsNull(result);
        }
    }
}
