namespace DM.Migrations.User
{
    using DM.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\User";
        }

        protected override void Seed(UserDbContext context)
        {
            context.Users.AddOrUpdate(DummyData.GetUsers());
        }
    }
}
