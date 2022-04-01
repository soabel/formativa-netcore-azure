using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Formativa.Users.Api.Application.Contracts;
using Formativa.Users.Api.Application.Dtos;
using Formativa.Users.Api.Infraestructure.Persistence.Database;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;
using Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts;
using Formativa.Users.Api.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace Formativa.Users.Api.Application
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        private readonly DatabaseContext context;


        public UserService(IUserRepository userRepository, IMapper mapper, DatabaseContext context)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.context = context;
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

        public Task<List<User>> FindByName(string name)
        {

            //' or 1=1 --

            //' TRUNCATE TABLE newtable --

            //return this.context.Users.FromSqlRaw($"SELECT * FROM Users.[User] WHERE name LIKE '%{name}%'").ToListAsync();

            var query = this.context.Users.Where(x => x.Name.Contains(name));

            return this.context.Users.Where(x => x.Name.Contains(name)).ToListAsync();


        }



        public int Update(int id, User user)
        {
            return this.userRepository.Update(id, user);
        }
    }
}
