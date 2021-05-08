using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Formativa.Users.Api.Application.Contracts;
using Formativa.Users.Api.Application.Dtos;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;
using Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts;

namespace Formativa.Users.Api.Application
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
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

            //var listDto = new List<UserDto>();
            //result.ForEach(x => {
            //    listDto.Add(new UserDto { Id = x.Id, Email = x.Email, Name = x.Name, Address=x.Address });
            //});

            return this.mapper.Map<List<UserDto>>(result);

        }

        public async Task<UserDto> FindById(int id)
        {
            var result= await this.userRepository.FindById(id);

            return this.mapper.Map<UserDto>(result);
        }

        public int Update(int id, User user)
        {
            return this.userRepository.Update(id, user);
        }
    }
}
