using E_Commerce.GeneralUser;
using E_Commerce.Products;
using System;

namespace E_Commerce.Screens
{
    internal class GeneralUserScreen
    {
        private GeneralUserManager generalUserManager;
        public GeneralUserScreen()
        {
            generalUserManager = new GeneralUserManager();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the E-Commerce Platform");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Buy a Product");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllProducts();
                        break;
                    case "2":
                        BuyProduct();
                        break;
                    case "3":
                        Console.WriteLine("Exiting... Thank you for visiting!");
                        return; 
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("List of Available Products:");
            var products = generalUserManager.GetAllProducts();

            if (products.Count > 0)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    var product = products[i];
                    Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} (Quantity: {product.Quantity})");
                }
            }
            else
            {
                Console.WriteLine("No products available.");
            }
        }

        private void BuyProduct()
        {
            Console.Clear();
            ViewAllProducts();  

            Console.Write("\nEnter the number of the product you want to buy: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber))
            {
                var products = generalUserManager.GetAllProducts();
                if (productNumber > 0 && productNumber <= products.Count)
                {
                    var selectedProduct = products[productNumber - 1];
                    if (selectedProduct.Quantity > 0)
                    {
                        selectedProduct.Quantity--;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nPurchase successful! You bought {selectedProduct.Name} for ${selectedProduct.Price}.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSorry, {selectedProduct.Name} is out of stock.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
