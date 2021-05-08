using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formativa.Users.Api.Infraestructure.Persistence.Database;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;
using Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Formativa.Users.Api.Infraestructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public int Add(User user)
        {
            this.databaseContext.Users.Add(user);
            return  this.databaseContext.SaveChanges();
        }

        public async Task<int> AddAsync(User user)
        {
            await this.databaseContext.Users.AddAsync(user);
            return await this.databaseContext.SaveChangesAsync();
        }

        public Task< List<User>> FindAll()
        {
            return this.databaseContext.Users.ToListAsync();
        }

        public int Delete(int id)
        {
            var user=  this.databaseContext.Users
                .Where(x=> x.Id==id).First();

            this.databaseContext.Users.Remove(user);

            return  this.databaseContext.SaveChanges();
        }

        public int Update(int id, User user)
        {
            var userEntity = this.databaseContext.Users
                .Where(x => x.Id == id).First();

            userEntity.Name = user.Name;
            userEntity.Address = user.Address;
            userEntity.Email = user.Email;

            this.databaseContext.Users.Update(userEntity);

            return this.databaseContext.SaveChanges();
        }

        public Task<User> FindById(int id)
        {
            return this.databaseContext.Users
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
