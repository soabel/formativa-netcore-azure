using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formativa.Users.Api.Application.Contracts;
using Formativa.Users.Api.Application.Dtos;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;
using Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Formativa.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }

        // GET: api/values
        [HttpGet]
        public Task<List<UserDto>> Get()
        {
            return this.userService.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public  Task<UserDto> Get(int id)
        {
            return  this.userService.FindById(id);
        }

        // POST api/values
        [HttpPost]
       
        public User Post([FromBody] User user)
        {
            this.userService.Add(user);

            return user;
        }

        // POST api/values
        [HttpPost]
        [Route("async")]
        public async Task<User> PostAsync([FromBody] User user)
        {
            await this.userService.AddAsync(user);

            return user;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User user)
        {
            this.userService.Update(id, user);

            return user;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public  void Delete(int id)
        {
            this.userService.Delete(id);

          
        }
    }
}
