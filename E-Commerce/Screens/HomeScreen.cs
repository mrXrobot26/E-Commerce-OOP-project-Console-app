using E_Commerce.Auth;
using E_Commerce.Utilities;
using System;
using System.Threading;

namespace E_Commerce.Screens
{
    internal class HomeScreen
    {

        private AuthUserManager userService;
        public HomeScreen()
        {
            userService = new AuthUserManager();
        }
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to E-Commerce App");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter your choice : ");
                string choice = Console.ReadLine();
                Console.ResetColor();
                switch (choice)
                {
                    case "1":
                        LoginScreen();
                        break;
                    case "2":
                        RegisterScreen();
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
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                if (loggedInUser.Role == UserRoles.Admin)
                {
                    var adminScreen = new AdminScreen();
                    adminScreen.Show();
                }
                else if (loggedInUser.Role == UserRoles.Customer)
                {
                    var generalScreen = new GeneralUserScreen();
                    generalScreen.Show();
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
