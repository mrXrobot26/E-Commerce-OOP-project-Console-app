﻿using E_Commerce.Auth;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.Admin
{
    internal class AdminManager : IAdminManager
    {
        private AuthUserManager userService;

        public AdminManager()
        {
            userService = new AuthUserManager();
        }

        public void CreateUser(User user)
        {
            userService.Register(user);
        }

        public List<User> GetAllUsers()
        {
            Console.WriteLine($"users count : {AuthUserManager.users.Count}");
            return AuthUserManager.users; 
        }
        public User GetUser(string email)
        {
            return AuthUserManager.users.FirstOrDefault(u => u.Email == email);
        }

        public void EditUser(string email, User updatedUser)
        {
            var user = GetUser(email);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.Role = updatedUser.Role;

                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public bool DeleteUser(string email)
        {
            var user = GetUser(email);
            if (user != null)
            {
                AuthUserManager.users.Remove(user);
                Console.WriteLine("User deleted successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("User not found.");
                return false;
            }
        }
    }
}
