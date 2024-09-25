using E_Commerce.Products;
using System;
using System.Linq;
using System.Collections.Generic;

namespace E_Commerce.GeneralUser
{
    internal class GeneralUserManager : IGeneralUserManager
    {
        public static List<Product> Products = DefaultProducts.GetDefaultProducts();

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public List<Product> GetProductsByName(string name)
        {
            return Products
                .Where(p => p.Name.ToLower() == name.ToLower())
                .ToList();
        }

        public void ShowProductsForPurchase()
        {
            Console.Clear();
            Console.WriteLine("Available Products for Purchase:");

            for (int i = 0; i < Products.Count; i++)
            {
                var product = Products[i];
                Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} (Quantity: {product.Quantity})");
            }

            Console.Write("\nEnter the product number to purchase: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= Products.Count)
            {
                ProcessPurchase(productNumber - 1);
            }
            else
            {
                Console.WriteLine("Invalid product number. Please try again.");
            }
        }

        private void ProcessPurchase(int productIndex)
        {
            var product = Products[productIndex];

            if (product.Quantity > 0)
            {
                product.Quantity--;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPurchase successful! You bought {product.Name} for ${product.Price}.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nSorry, {product.Name} is out of stock.");
                Console.ResetColor();
            }

        }
    }
}
