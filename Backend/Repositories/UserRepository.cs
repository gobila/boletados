using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;

namespace Backend.Repositories
{    public class UserRepository
    {
        public static IList<User> Users = new List<User>
        {

            new User
            {
                Username = "Lucas",
                Password = "123"
            },

            new User
            {
                Username = "Mariana",
                Password = "123"
            },
        };


        public User GetByUsername(string username)
        {
            return Users.Where(x => x.Username.ToLower() == username.ToLower())
                .FirstOrDefault();
        }
    }
}