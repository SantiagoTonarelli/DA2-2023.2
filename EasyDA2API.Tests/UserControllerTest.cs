using APIModels;
using Domain;
using EasyDA2API.Controllers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel;

namespace EasyDA2API.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void GetAllUserCorrectTest()
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
            var expectedMappedResult = expected.Select(u => new UserResponse(u)).ToList();
            Mock<IUserLogic> logic = new Mock<IUserLogic>(MockBehavior.Strict);
            logic.Setup(logic => logic.GetAllUsers()).Returns(expected);
            var userController = new UserController(logic.Object);
            OkObjectResult expectedObjectResult = new OkObjectResult(expectedMappedResult);

            // Act
            var result = userController.GetAllUsers();

            // Assert
            logic.VerifyAll();
            OkObjectResult resultObject = result as OkObjectResult;
            List<UserResponse> resultValue = resultObject.Value as List<UserResponse>;
            Assert.AreEqual(resultObject.StatusCode, expectedObjectResult.StatusCode);
            // Improve this
            Assert.AreEqual(resultValue.First().Name, expectedMappedResult.First().Name);
        }
    }
}