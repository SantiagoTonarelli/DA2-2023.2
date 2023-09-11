using Domain;
using Moq;
using Logic;
using DataAcces.Interfaces;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace Logic.Tests
{
    [TestClass]
    public class UserLogicTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            //Arrage 
            IEnumerable<User> expected = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Juan",
                    Age = 37,
                    Pass = "213213123"
                }
            };
            Mock<IUserRepository> repo = new Mock<IUserRepository>(MockBehavior.Strict);
            repo.Setup(logic => logic.GetAllUsers(It.IsAny<Func<User,bool>>())).Returns(expected);
            var userLogic = new UserLogic(repo.Object);

            // Act
            var result = userLogic.GetAllUsers("");

            // Assert
            repo.VerifyAll();
            // Improve this
            Assert.AreEqual(result.First().Name, expected.First().Name);
        }

        [TestMethod]
        public void CreateUserCorrect()
        {
            //Arrage 
            User expected = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Juan",
                Age = 37,
                Pass = "213213123"
            };
            Mock<IUserRepository> repo = new Mock<IUserRepository>(MockBehavior.Strict);
            repo.Setup(logic => logic.CreateUser(It.IsAny<User>())).Returns(expected);
            repo.Setup(logic => logic.Exist(It.IsAny<Func<User, bool>>())).Returns(false);
            var userLogic = new UserLogic(repo.Object);

            // Act
            var result = userLogic.CreateUser(expected);

            // Assert
            repo.VerifyAll();
            // Improve this
            Assert.AreEqual(result.Name, expected.Name);
        }

        [TestMethod]
        public void CreateUserIncorrect()
        {
            //Arrage 
            Exception ex = null;
            Mock<IUserRepository> repo = null;
            try
            {
                User expected = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Juan",
                    Age = 4,
                    Pass = "213213123"
                };
                repo = new Mock<IUserRepository>(MockBehavior.Strict);
                var userLogic = new UserLogic(repo.Object);

                // Act
                var result = userLogic.CreateUser(expected);
            } 
            catch (Exception e)
            {
                ex = e;
            }

            // Assert
            repo.VerifyAll();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'Age Invalid')");
        }

        [TestMethod]
        public void CreateUserAlreadyExist()
        {
            //Arrage 
            Exception ex = null;
            Mock<IUserRepository> repo = null;
            try
            {
                User expected = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Alex",
                    Age = 10,
                    Pass = "213213123"
                };
                repo = new Mock<IUserRepository>(MockBehavior.Strict);
                repo.Setup(repo => repo.Exist(It.IsAny<Func<User, bool>>())).Returns(true);
                var userLogic = new UserLogic(repo.Object);

                // Act
                var result = userLogic.CreateUser(expected);
            }
            catch (Exception e)
            {
                ex = e;
            }

            // Assert
            repo.VerifyAll();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
            Assert.AreEqual(ex.Message, "User already exist");
        }
    }
}