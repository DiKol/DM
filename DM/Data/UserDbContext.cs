using DataMart.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DM.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(): base("DefaultConnection") {}

        public DbSet<User> Users { get; set; }
    }
}