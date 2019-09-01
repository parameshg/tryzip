using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.Domain;

namespace Zip.Database.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserById(Guid id);

        Task<User> GetUserByEmail(string email);

        Task<bool> CreateUser(Guid id, string name, string email, float salary, float expense);
    }

    public class UserRepository : IUserRepository
    {
        private ZipDbContext Context { get; }

        public UserRepository(ZipDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<User>> GetUsers()
        {
            var result = new List<User>();

            await Task.Run(() =>
            {
                foreach (var entity in Context.Users.ToArray())
                {
                    result.Add(new User()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Email = entity.Email,
                        Salary = entity.Salary,
                        Expense = entity.Expense
                    });
                }
            });

            return result;
        }

        public async Task<User> GetUserById(Guid id)
        {
            User result = null;

            await Task.Run(() =>
            {
                var entity = Context.Users.FirstOrDefault(i => i.Id.Equals(id));

                if (entity != null)
                {
                    result = new User()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Email = entity.Email,
                        Salary = entity.Salary,
                        Expense = entity.Expense
                    };
                }
            });

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User result = null;

            await Task.Run(() =>
            {
                var entity = Context.Users.FirstOrDefault(i => i.Email.Equals(email));

                if (entity != null)
                {
                    result = new User()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Email = entity.Email,
                        Salary = entity.Salary,
                        Expense = entity.Expense
                    };
                }
            });

            return result;
        }

        public async Task<bool> CreateUser(Guid id, string name, string email, float salary, float expense)
        {
            var result = false;

            await Context.Users.AddAsync(new Entities.User()
            {
                Id = id,
                Name = name,
                Email = email,
                Salary = salary,
                Expense = expense
            });

            result = await Context.SaveChangesAsync() > 0;

            return result;
        }
    }
}