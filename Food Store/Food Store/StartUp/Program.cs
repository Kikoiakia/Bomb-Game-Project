using System;
using System.Collections.Generic;
using System.IO;
using StartUp.Business;
using StartUp.Data.Models;
using StartUp.Views;

namespace StartUp
{
    class Program
    {
        public static ProductController ProductController = new ProductController();

        static void Main(string[] args)
        {

            //Display display = new Display();
            ProductController.ResetWholeProduct();



            //  for (int i = 0; i <= 1; i++)
            //    {

            //        try
            //        {
            //            Console.WriteLine("Insert Name(string), Price(double), Stock(int) and ProductStoreId(int): ");
            //            string[] cmdArgs = Console.ReadLine().Split(' ');

            //            var name = cmdArgs[0];
            //            var price = double.Parse(cmdArgs[1]);
            //            var stock = int.Parse(cmdArgs[2]);
            //            var expiryDate = DateTime.Today;
            //            var productStoreId = int.Parse(cmdArgs[3]);

            //            Product product = new Product(name, price, stock, expiryDate, productStoreId);

            //            ProductController.AddProduct(product);

            //        }
            //        catch(InvalidDataException e)
            //        {
            //            Console.WriteLine(e);
            //        }
            //    }


            //List<Product> products = ProductController.GetAllProducts();
            //    foreach (var product1 in products)
            //    {
            //        WriteProduct(product1);
            //    }

            //ResetProducts(products);



        }


        
        //public static void WriteProduct(Product product)
        //{
        //    Console.WriteLine($"Id: {product.Id}\t" +
        //                      $"Name: {product.Name}\t" +
        //                      $"Price: {product.Price}\t" +
        //                      $"Stock: {product.Stock}\t" +
        //                      $"ExpiryDate: {product.ExpiryDate}\t" +
        //                      $"ProductStoreId: {product.ProductStoreId}");
        //}

        //public static void ResetProducts(List<Product> products)
        //{
        //    foreach (var product in products)
        //    {
        //        ProductController.DeleteProduct(product.Id);
        //    }
        //    ProductController.ResetWholeProduct();
        //}
        


    }
}
