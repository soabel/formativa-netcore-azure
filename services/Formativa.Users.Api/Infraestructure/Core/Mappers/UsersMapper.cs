using System;
using AutoMapper;
using Formativa.Users.Api.Application.Dtos;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;

namespace Formativa.Users.Api.Infraestructure.Core.Mappers
{
    public class UsersMapper: Profile
    {
        public UsersMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}
