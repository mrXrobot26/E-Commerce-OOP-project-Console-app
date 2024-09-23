using E_Commerce.Auth;
using E_Commerce.Utilities;
using System;
using System.Threading;

namespace E_Commerce.Screens
{
    internal class HomeScreen
    {
        private UserService userService;
        public HomeScreen()
        {
            userService = new UserService();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to E-Commerce App");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter your choice : ");
                string choice = Console.ReadLine();
                Console.ResetColor();

                switch (choice)
                {
                    case "1":
                        RegisterScreen();
                        break;
                    case "2":
                        LoginScreen();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
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
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Company");
            Console.WriteLine("3. Customer");
            Console.ResetColor();
            Console.Write("Enter your choice (1-3): ");

            string roleChoice = Console.ReadLine();
            string role = string.Empty;

            switch (roleChoice)
            {
                case "1":
                    role = UserRoles.Admin;
                    break;
                case "2":
                    role = UserRoles.Company;
                    break;
                case "3":
                    role = UserRoles.Customer;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Customer.");
                    role = UserRoles.Customer;
                    break;
            }

            userService.Register(new User
            {
                Id = Guid.NewGuid().ToString(), // globally unique identifier
                Name = name,
                Email = email,
                Password = password,
                Role = role
            });

            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }


        private void LoginScreen()
        {
            Console.Clear();
            Console.WriteLine("Login with your credentials:");

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (userService.Login(email, password))
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Login failed. Please try again.");
                Thread.Sleep(1000); 
            }
        }
    }
}
