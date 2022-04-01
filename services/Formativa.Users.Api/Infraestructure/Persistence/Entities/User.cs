using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Formativa.Users.Api.Infraestructure.Persistence.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
