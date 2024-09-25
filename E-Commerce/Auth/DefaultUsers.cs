using E_Commerce.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Auth
{
    internal static class DefaultUsers
    {
        public static List<User> GetDefaultUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = "1",
                    Name = "Admin",
                    Role = UserRoles.Admin,
                    Email = "admin@gmail.com",
                    Password = "Admin123*"
                },
                new User
                {
                    Id = "3",
                    Name = "Customer",
                    Role = UserRoles.Customer,
                    Email = "customer@gmail.com",
                    Password = "Customer123*"
                },
                new User
                {
                    Id = "4",
                    Name = "Test",
                    Role = UserRoles.Admin,
                    Email = "1",
                    Password = "1"
                },
                new User
                {
                    Id = "4",
                    Name = "TestCustomer",
                    Role = UserRoles.Customer,
                    Email = "2",
                    Password = "2"
                }
            };
        }
    }
}
