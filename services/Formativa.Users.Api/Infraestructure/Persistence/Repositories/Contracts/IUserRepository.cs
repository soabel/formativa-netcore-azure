using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;

namespace Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> FindAll();
    }
}
