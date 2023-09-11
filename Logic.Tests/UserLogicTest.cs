using Domain;
using Moq;
using Logic;
using DataAcces.Interfaces;

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
            Mock<IUserRepository> logic = new Mock<IUserRepository>(MockBehavior.Strict);
            logic.Setup(logic => logic.GetAllUsers(It.IsAny<Func<User,bool>>())).Returns(expected);
            var userLogic = new UserLogic(logic.Object);

            // Act
            var result = userLogic.GetAllUsers("");

            // Assert
            logic.VerifyAll();
            // Improve this
            Assert.AreEqual(result.First().Name, expected.First().Name);
        }
    }
}