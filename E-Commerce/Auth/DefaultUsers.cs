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
                    Name = "Admin User",
                    Role = UserRoles.Admin,
                    Email = "admin@ecommerce.com",
                    Password = "admin123"
                },
                new User
                {
                    Id = "2",
                    Name = "Company User",
                    Role = UserRoles.Company,
                    Email = "company@ecommerce.com",
                    Password = "company123"
                },
                new User
                {
                    Id = "3",
                    Name = "Customer User",
                    Role = UserRoles.Customer,
                    Email = "customer@ecommerce.com",
                    Password = "customer123"
                }
            };
        }
    }
}
