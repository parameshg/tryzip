using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.Domain;

namespace Zip.Database.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccounts();

        Task<bool> CreateAccount(Guid id, Guid userId, string name, float balance);
    }

    public class AccountRepository : IAccountRepository
    {
        private ZipDbContext Context { get; }

        public AccountRepository(ZipDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Account>> GetAccounts()
        {
            var result = new List<Account>();

            await Task.Run(() =>
            {
                foreach (var entity in Context.Accounts.ToArray())
                {
                    result.Add(new Account()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Balance = entity.Balance
                    });
                }
            });

            return result;
        }

        public async Task<bool> CreateAccount(Guid id, Guid userId, string name, float balance)
        {
            var result = false;

            var user = Context.Users.FirstOrDefault(i => i.Id.Equals(userId));

            if (user != null)
            {
                await Context.Accounts.AddAsync(new Entities.Account()
                {
                    Id = id,
                    User = user,
                    Name = name,
                    Balance = balance
                });

                result = await Context.SaveChangesAsync() > 0;
            }

            return result;
        }
    }
}