using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zip.Database;
using Zip.Database.Repositories;

namespace Zip.UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        private ZipDbContext Context { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Context = new ZipDbContext(new DbContextOptionsBuilder().UseInMemoryDatabase("zip.db").Options);
        }

        [TestMethod]
        public void TestUserCreation()
        {
            var repository = new UserRepository(Context);

            var id = Guid.NewGuid();

            var created = repository.CreateUser(id, "test", "test@test.com", 5000, 2000).GetAwaiter().GetResult();

            Assert.IsTrue(created);

            var user = repository.GetUserById(id).GetAwaiter().GetResult();

            Assert.IsNotNull(user);

            Assert.AreEqual(user.Id, id);
            Assert.AreEqual(user.Name, "test");
            Assert.AreEqual(user.Email, "test@test.com");
            Assert.AreEqual(user.Salary, 5000);
            Assert.AreEqual(user.Expense, 2000);
        }

        [TestMethod]
        public void TestAccountCreation()
        {
            var users = new UserRepository(Context);

            var userId = Guid.NewGuid();

            var userCreated = users.CreateUser(userId, "test", "test@test.com", 5000, 2000).GetAwaiter().GetResult();

            Assert.IsTrue(userCreated);

            var user = users.GetUserById(userId).GetAwaiter().GetResult();

            Assert.IsNotNull(user);

            Assert.AreEqual(user.Id, userId);
            Assert.AreEqual(user.Name, "test");
            Assert.AreEqual(user.Email, "test@test.com");
            Assert.AreEqual(user.Salary, 5000);
            Assert.AreEqual(user.Expense, 2000);

            var accounts = new AccountRepository(Context);

            var accountId = Guid.NewGuid();

            var accountCreated = accounts.CreateAccount(accountId, userId, "test-account", 1000).GetAwaiter().GetResult();

            Assert.IsTrue(accountCreated);
        }
    }
}