using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void TestAddUser()
        {
            // Arrage 
            var context = CreateDbContext("TestAddUser");
            var repository = new UserRepository(context);
            User expected = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Juan",
                Age = 37,
                Pass = "213213123"
            };

            // Act
            var result = repository.CreateUser(expected);

            // Assert 
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void TestExistUser()
        {
            // Arrage 
            var context = CreateDbContext("TestExistUser");
            User expected = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Juan",
                Age = 37,
                Pass = "213213123"
            };
            context.Set<User>().Add(expected);
            context.SaveChanges();
            var repository = new UserRepository(context);
            
            // Act
            var result = repository.Exist((User u)=> u.Name == "Juan");

            // Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNoExistUser()
        {
            // Arrage 
            var context = CreateDbContext("TestNoExistUser");
            User expected = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Jua2n",
                Age = 37,
                Pass = "213213123"
            };
            context.Set<User>().Add(expected);
            context.SaveChanges();
            var repository = new UserRepository(context);

            // Act
            var result = repository.Exist((User u) => u.Name == "Juan");

            // Assert 
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetUserByName()
        {
            // Arrage 
            var context = CreateDbContext("TestGetUserByName");
            User expected = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Jua2n",
                Age = 37,
                Pass = "213213123"
            };
            User expected2 = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Juan",
                Age = 37,
                Pass = "213213123"
            };
            context.Set<User>().Add(expected);
            context.Set<User>().Add(expected2);
            context.SaveChanges();
            var repository = new UserRepository(context);

            // Act
            var result = repository.GetAllUsers((User u) => u.Name == "Juan");

            // Assert 
            Assert.AreEqual(result.Count(),1);
            // Chequear el otro usuario
        }

        private DbContext CreateDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(dbName).Options;
            return new Context(options);
        }
    }
}