using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;
using Formativa.Users.Api.Infraestructure.Persistence.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Formativa.Users.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        // GET: api/values
        [HttpGet]
        public Task<List<User>> Get()
        {
            return this.userRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
