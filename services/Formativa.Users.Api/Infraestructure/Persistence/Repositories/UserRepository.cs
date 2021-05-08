using System;
using System.Collections.Generic;
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

        public Task< List<User>> FindAll()
        {
            return this.databaseContext.Users.ToListAsync();
        }
    }
}
