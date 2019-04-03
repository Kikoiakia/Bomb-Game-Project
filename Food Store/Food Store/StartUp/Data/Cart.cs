using System;
using System.Collections.Generic;
using System.Linq;
using StartUp.Business;
using StartUp.Data.Models;

namespace StartUp.Data
{
    public class Cart
    {
        private ProductController controller;
        private List<Product> products;
        private List<int> productQuantity;
        
        public Cart()
        {
            products = new List<Product>();
            productQuantity = new List<int>();
            controller = new ProductController();
        }
        
        /// <summary>
        /// Adds a product to the cart with given quanitity
        /// </summary>
        /// <param name="id"></param>
        public void AddToCart(Product product, int quanitity)
        {
           products.Add(product);
           productQuantity.Add(quanitity);
        }

        /// <summary>
        /// Shows all products in the cart
        /// </summary>
        public void ShowProductsInCart()
        {
            int productId = 1;
            foreach (var product in products)
            {
                Console.WriteLine($"{productId}. {productQuantity[productId-1]} {product.Name} for {product.Price * productQuantity[productId-1]:f2}$");
                productId++;
            }
        }

        /// <summary>
        /// Removes a product from the cart with given id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveProductFromCart(int index)
        {
            products.RemoveAt(index-1);
            productQuantity.RemoveAt(index - 1);
        }

        /// <summary>
        /// Removes all products from the cart by making a new list
        /// </summary>
        public void RemoveProductsFromCart()
        {
            products = new List<Product>();
            productQuantity = new List<int>();
        }

        public double GetPrice()
        {
            double finalPrice = 0;
            int productId = 1;
            foreach (var product in products)
            {
                finalPrice += product.Price * productQuantity[productId - 1];
                productId++;
            }

            return finalPrice;
        }

        public void DecreaseQuanitity()
        {
            int productId = 1;
            foreach (var product in products)
            {
                product.Stock -= productQuantity[productId - 1];
                controller.UpdateProduct(product);
                productId++;
            }
        }
    }
}