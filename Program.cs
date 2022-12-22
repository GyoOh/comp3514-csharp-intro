using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using newEf.NW;

namespace newEf
{
    class Program
    {
        static NorthwindContext context = new NorthwindContext();
        static void Main(string[] args)
        {
            // GetAllCategories();
            GetAllProducts();
            InsertCategory();
            GetAllProducts();
            // GetAllCategories();
            static void GetAllCategories()
            {
                foreach (var c in context.Categories)
                {
                    Console.WriteLine($"{c.CategoryId}");
                }
                Console.WriteLine("=============================");
            }
            static void GetAllProducts()
            {

                foreach (var p in context.Products)
                {
                    Console.WriteLine($"{p.CategoryId}\t{p.ProductName}\t {p.UnitPrice}");
                }
                Console.WriteLine("=============================");
            }
            static void InsertCategory()
            {
                string name = "";
                decimal price = 0;
                int id = 0;
                Console.WriteLine("Plase enter your category id");
                string newName = Console.ReadLine();
                Console.WriteLine("Please enter your productname");
                name = Console.ReadLine();
                if (Int32.TryParse(newName, out id))
                {
                    Console.WriteLine("Plase enter your unit price");
                    newName = Console.ReadLine();
                    if (decimal.TryParse(newName, out price))
                    {
                        var newCat = new Product()
                        {
                            CategoryId = id,
                            ProductName = name,
                            UnitPrice = price,
                        };
                        context.Products.Add(newCat);
                        context.SaveChanges();
                    }

                }
            }

        }
    }
}
