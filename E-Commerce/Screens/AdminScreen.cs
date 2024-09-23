using E_Commerce.Admin;
using E_Commerce.Auth;
using E_Commerce.Utilities;
using System;
using System.Threading;

namespace E_Commerce.Screens
{
    internal class AdminScreen
    {
        private AdminService adminService;

        public AdminScreen()
        {
            adminService = new AdminService();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin Dashboard");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Get All Users");
                Console.WriteLine("3. Get User by Email");
                Console.WriteLine("4. Edit User by Email");
                Console.WriteLine("5. Delete User by Email");
                Console.WriteLine("6. Exit");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.ResetColor();

                switch (choice)
                {
                    case "1":
                        RegisterScreen();
                        break;
                    case "2":
                        GetAllUsersScreen();
                        break;
                    case "3":
                        GetUserScreen();
                        break;
                    case "4":
                        EditUserScreen();
                        break;
                    case "5":
                        DeleteUserScreen();
                        break;
                    case "6":
                        return; // Exit the admin screen
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void RegisterScreen()
        {
            Console.Clear();
            Console.WriteLine("Enter a new user registration:");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Select Role:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Company");
            Console.WriteLine("3. Customer");
            Console.ResetColor();
            Console.Write("Enter your choice (1-3): ");

            string roleChoice = Console.ReadLine();
            string role = roleChoice switch
            {
                "1" => UserRoles.Admin,
                "2" => UserRoles.Company,
                "3" => UserRoles.Customer,
                _ => UserRoles.Customer 
            };

            adminService.CreateUser(new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Email = email,
                Password = password,
                Role = role
            });

            Console.WriteLine("User created successfully.");
            Console.WriteLine("Press any key to go back to the admin dashboard...");
            Console.ReadKey();
        }

        private void GetAllUsersScreen()
        {
            Console.Clear();
            var users = adminService.GetAllUsers();
            Console.WriteLine("All Registered Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"- {user.Name} ({user.Email}) - Role: {user.Role}");
            }

            Console.WriteLine("Press any key to go back to the admin dashboard...");
            Console.ReadKey();
        }

        private void GetUserScreen()
        {
            Console.Clear();
            Console.Write("Enter Email of the user to find: ");
            string email = Console.ReadLine();

            var user = adminService.GetUser(email);
            if (user != null)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            Console.WriteLine("Press any key to go back to the admin dashboard...");
            Console.ReadKey();
        }

        private void EditUserScreen()
        {
            Console.Clear();
            Console.Write("Enter Email of the user to edit: ");
            string email = Console.ReadLine();

            var existingUser = adminService.GetUser(email);
            if (existingUser != null)
            {
                Console.Write("Enter new name (or press Enter to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    existingUser.Name = name;

                Console.Write("Enter new password (or press Enter to keep current): ");
                string password = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(password))
                    existingUser.Password = password;

                adminService.EditUser(email, existingUser);
                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            Console.WriteLine("Press any key to go back to the admin dashboard...");
            Console.ReadKey();
        }

        private void DeleteUserScreen()
        {
            Console.Clear();
            Console.Write("Enter Email of the user to delete: ");
            string email = Console.ReadLine();

            if (adminService.DeleteUser(email))
            {
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            Console.WriteLine("Press any key to go back to the admin dashboard...");
            Console.ReadKey();
        }
    }
}
