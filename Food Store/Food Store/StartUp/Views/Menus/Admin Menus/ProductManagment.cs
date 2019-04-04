using System;
using StartUp.Business;
using StartUp.Data.Models;

namespace StartUp.Views.Menus
{
    /// <summary>
    /// Class used to control the product database
    /// </summary>
    public class ProductManagment
    {
        /// <summary>
        /// Shows the stock menu
        /// </summary>
        public void ShowProductMenu()
        {
            
            string[] command;
            var productController = new ProductController();
            do
            {
                Console.WriteLine("Product managment Menu:\n" +
                                  "Availabel products:\n");
                var products = new ProductController().GetAllProducts();
                foreach (var product in products)
                {
                    Console.WriteLine($"ID:{product.Id}\t " +
                                      $"Name:{product.Name}\t " +
                                      $"Price:{product.Price}\t " +
                                      $"Available in stock:{product.Stock}\t " +
                                      $"Expiry Date:{product.ExpiryDate}\t " +
                                      $"Product store id:{product.ProductStoreId}");
                }

                Console.WriteLine($"\nTo add a new product use Add");
                Console.WriteLine($"To remove a product DELETE (Product ID)");
                Console.WriteLine($"To update a product use Update");
                Console.WriteLine($"If you want to delete the whole product table and reset it's id use DELETEALL");
                Console.WriteLine("B. Exit Managment Menu\n\n");
                
                Console.Beep(500, 100);
                command = Console.ReadLine().Split();


                if (command[0].ToUpper() == "ADD")
                {
                    Console.Write("Product Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Product Price: ");
                    var price = double.Parse(Console.ReadLine());

                    Console.Write("How much is in stock: ");
                    var stock = int.Parse(Console.ReadLine());

                    Console.Write("Expiry date (YYYY:MM:DD): ");
                    var dateInText = Console.ReadLine().Split(':');
                    var date = new DateTime(int.Parse(dateInText[0]), int.Parse(dateInText[1]), int.Parse(dateInText[2]));

                    Console.Write("In which store is it (use store id): ");
                    var productStoreId = int.Parse(Console.ReadLine());

                    var product = new Product(name,price,stock,date,productStoreId);
                    productController.AddProduct(product);
                }

                if (command[0].ToUpper() == "DELETE")
                {
                    productController.DeleteProduct(int.Parse(command[1]));
                }

                if (command[0].ToUpper() == "UPDATE")
                {
                    Console.Write("Product ID: ");
                    var id = int.Parse(Console.ReadLine());
                    var product = productController.GetProduct(id);

                    Console.Write("Product Name: ");
                    product.Name = Console.ReadLine();
                    
                    Console.Write("Product Price: ");
                    product.Price = double.Parse(Console.ReadLine());
                    
                    Console.Write("How much is in stock: ");
                    product.Stock = int.Parse(Console.ReadLine());

                    Console.Write("Expiry date (YYYY:MM:DD): ");
                    var dateInText = Console.ReadLine().Split(':');
                    product.ExpiryDate = new DateTime(int.Parse(dateInText[0]), int.Parse(dateInText[1]), int.Parse(dateInText[2]));

                    Console.Write("In which store is it (use store id): ");
                    product.ProductStoreId = int.Parse(Console.ReadLine());

                    productController.UpdateProduct(product);
                }

                if (command[0].ToUpper() == "DELETEALL")
                {
                    Console.WriteLine("ARE YOU SURE? Y/N");
                    command = Console.ReadLine().Split();
                    if (command[0].ToUpper() == "YES" || command[0].ToUpper() == "Y")
                    {
                        foreach (var product in products)
                        {
                            productController.DeleteProduct(product.Id);
                        }

                        productController.ResetWholeProduct();
                        Console.WriteLine("It is done. The whole table has been reset");
                    }
                }
                Console.Clear();

            } while (command[0].ToUpper() != "B");
        }
    }
}