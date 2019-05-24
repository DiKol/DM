using DataMart.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DM.Data
{
    public class DummyData
    {
        public static User[] GetUsers()
        {

            var users = new List<User>()
            {
                new User()
                {
                    Id = 1, FirstName = "Dmytro1", LastName = "Kolesnyk", Birth = DateTime.Now, Order = 1
                },
                new User()
                {
                    Id = 2, FirstName = "Dmytro2", LastName = "Kolesnyk", Birth = DateTime.Now, Order = 2
                },
                new User()
                {
                    Id = 3, FirstName = "Dmytro3", LastName = "Kolesnyk", Birth = DateTime.Now, Order = 3
                },


            };
            return users.ToArray();
        }
    }
}