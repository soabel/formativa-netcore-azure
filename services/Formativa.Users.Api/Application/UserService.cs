using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Formativa.Users.Api.Application.Contracts;
using Formativa.Users.Api.Application.Dtos;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;
using Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts;

namespace Formativa.Users.Api.Application
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public int Add(User user)
        {
            return this.userRepository.Add(user);
        }

        public Task<int> AddAsync(User user)
        {
            return this.userRepository.AddAsync(user);
        }

        public int Delete(int id)
        {
            return this.userRepository.Delete(id);
        }

        public async Task<List<UserDto>> FindAll()
        {
            var result = await this.userRepository.FindAll();

            var listDto = new List<UserDto>();
            result.ForEach(x => {
                listDto.Add(new UserDto { Id = x.Id, Email = x.Email, Name = x.Name, Address=x.Address });
            });

            return listDto  ;
        }

        public Task<User> FindById(int id)
        {
            return this.userRepository.FindById(id);
        }

        public int Update(int id, User user)
        {
            return this.userRepository.Update(id, user);
        }
    }
}
