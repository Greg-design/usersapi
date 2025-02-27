using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UsersApi.Models;

namespace UsersApi.Data
{
    public class UsersApiDBContext : DbContext
    {
        public UsersApiDBContext(DbContextOptions<UsersApiDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
