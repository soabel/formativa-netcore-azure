using System;

using Microsoft.EntityFrameworkCore;
using Formativa.Users.Api.Infraestructure.Persistence.Entities;


namespace Formativa.Users.Api.Infraestructure.Persistence.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("User", "Users");

        }
    }
}
