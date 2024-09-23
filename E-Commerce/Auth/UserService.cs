using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.Auth
{
    internal class UserService : IUserService
    {
        public static List<User> users;
        public UserService()
        {
            users = DefaultUsers.GetDefaultUsers();
        }

        public void Register(User user)
        {
            if (!CheckIfUserExists(user.Email))
            {
                users.Add(user);
                Console.WriteLine($"User {user.Name} registered successfully.");
            }
            else
            {
                Console.WriteLine("User already exists.");
            }
        }

        public bool Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Login successful. Welcome {user.Name[0]} ({user.Role})");
                Console.ResetColor();
                return true;
            }
            Console.WriteLine("Invalid email or password.");
            return false;
        }


        public bool CheckIfUserExists(string email)
        {
            return users.Any(u => u.Email == email);
        }
    }
}
