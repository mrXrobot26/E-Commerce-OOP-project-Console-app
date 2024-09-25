using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Products
{
    internal static class DefaultProducts
    {
        public static List<Product> GetDefaultProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "iPhone 14",
                    Description = "Apple's latest smartphone with A15 chip.",
                    Price = 999.99m,
                    Quantity = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "MacBook Pro",
                    Description = "Apple's professional laptop with M2 chip.",
                    Price = 1999.99m,
                    Quantity = 30
                },
                new Product
                {
                    Id = 3,
                    Name = "Samsung Galaxy S22",
                    Description = "Samsung's flagship smartphone with Snapdragon processor.",
                    Price = 899.99m,
                    Quantity = 45
                },
                new Product
                {
                    Id = 4,
                    Name = "Sony WH-1000XM5",
                    Description = "Noise cancelling wireless headphones.",
                    Price = 349.99m,
                    Quantity = 120
                },
                new Product
                {
                    Id = 5,
                    Name = "Dell XPS 13",
                    Description = "Dell's ultra-portable laptop with Intel i7 processor.",
                    Price = 1499.99m,
                    Quantity = 20
                }
            };
        }
    }
}
