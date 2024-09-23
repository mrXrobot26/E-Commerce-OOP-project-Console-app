using E_Commerce.Auth;
using System.Collections.Generic;

namespace E_Commerce.Admin
{
    internal interface IAdminService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User GetUser(string email);
        void EditUser(string email, User updatedUser);
        bool DeleteUser(string email);
    }
}
