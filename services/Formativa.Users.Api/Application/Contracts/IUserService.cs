using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formativa.Users.Api.Application.Dtos;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;

namespace Formativa.Users.Api.Application.Contracts
{
    public interface IUserService
    {
        Task<List<UserDto>> FindAll();

        Task<UserDto> FindById(int id);

        int Add(User user);

        Task<int> AddAsync(User user);
        int Delete(int id);
        int Update(int id, User user);
    }
}
