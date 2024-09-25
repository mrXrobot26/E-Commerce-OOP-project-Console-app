using E_Commerce.Auth;
using E_Commerce.Products;
using System.Collections.Generic;

namespace E_Commerce.Admin
{
    internal interface IAdminManager
    {
        // User management
        void CreateUser(User user);
        List<User> GetAllUsers();
        User GetUser(string email);
        void EditUser(string email, User updatedUser);
        bool DeleteUser(string email);

    }
}
