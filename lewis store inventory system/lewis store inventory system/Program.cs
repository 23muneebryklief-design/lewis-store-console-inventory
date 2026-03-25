using System;
using N_Product;
using N_Sale;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("==============");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Sell Product");
                Console.WriteLine("3. View Product");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Exit");

                Console.Write("Choose option: ");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        AddProduct();
                        break;

                    case "2":
                        SellProduct();
                        break;

                    case "3":
                        ViewProduct(); 
                        break;
                    case "4":
                        DeleteProduct();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // ADD PRODUCT
        static void AddProduct()
        {
            Product p = new Product();

            Console.Write("Name: ");
            p.ProductName = Console.ReadLine();

            Console.Write("Description: ");
            p.Description = Console.ReadLine();

            Console.Write("Price: ");
            p.PriceExcludingVAT = decimal.Parse(Console.ReadLine());

            Console.Write("Quantity: ");
            p.QuantityInStock = int.Parse(Console.ReadLine());

            p.AddProduct(p);

            Console.WriteLine("Product added!");
        }

        // SELL PRODUCT
        static void SellProduct()
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Sale sale = new Sale();
            sale.SellProduct(id, qty);
        }
        static void ViewProduct()
        {
            Product product = new Product();
            var products = product.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID} | {p.ProductName} | {p.PriceExcludingVAT} | Stock: {p.QuantityInStock}");
            }
        }
        static void DeleteProduct()
        {
            Console.Write("Enter Product ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Product product = new Product();
            product.DeleteProduct(id);
        }
    }
}