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
            userService.Register(new User
            {
                Id = Guid.NewGuid().ToString(), // globally unique identifier
                Name = name,
                Email = email,
                Password = password,
                Role = UserRoles.Customer
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

            var loggedInUser = userService.Login(email, password);
            if (loggedInUser != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Login successful! Welcome, {loggedInUser.Name}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                if (loggedInUser.Role == UserRoles.Admin)
                {
                    var adminScreen = new AdminScreen();
                    adminScreen.Show();
                }
                else
                {
                    Console.WriteLine($"Logged in as {loggedInUser.Role}. Redirecting...");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login failed. Please try again.");
                Console.ResetColor();
                Thread.Sleep(1000);
            }
        }

    }
}
