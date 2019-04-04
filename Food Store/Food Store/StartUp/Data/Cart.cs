using System;
using System.Collections.Generic;
using StartUp.Business;
using StartUp.Data.Models;

namespace StartUp.Data
{
    public class Cart
    {
        private readonly ProductController _productController;
        private List<Product> _products;
        private List<int> _productQuantity;
        
        public Cart()
        {
            _products = new List<Product>();
            _productQuantity = new List<int>();
            _productController = new ProductController();
        }

        /// <summary>
        /// Adds a product to the cart with given quantity
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddToCart(Product product, int quantity)
        {
           _products.Add(product);
           _productQuantity.Add(quantity);
        }

        /// <summary>
        /// Shows all products in the cart
        /// </summary>
        public void ShowProductsInCart()
        {
            int productId = 1;
            foreach (var product in _products)
            {
                Console.WriteLine($"{productId}. {_productQuantity[productId-1]} {product.Name} for {product.Price * _productQuantity[productId-1]:f2}$");
                productId++;
            }
        }

        /// <summary>
        /// Removes a product from the cart with given id
        /// </summary>
        /// <param name="index"></param>
        public void RemoveProductFromCart(int index)
        {
            _products.RemoveAt(index-1);
            _productQuantity.RemoveAt(index - 1);
        }

        /// <summary>
        /// Removes all products from the cart by making a new list
        /// </summary>
        public void RemoveProductsFromCart()
        {
            _products = new List<Product>();
            _productQuantity = new List<int>();
        }

        /// <summary>
        /// Gets the total price for all items in the cart
        /// </summary>
        /// <returns></returns>
        public double GetPrice()
        {
            double finalPrice = 0;
            int productId = 1;
            foreach (var product in _products)
            {
                finalPrice += product.Price * _productQuantity[productId - 1];
                productId++;
            }

            return finalPrice;
        }

        /// <summary>
        /// Uses the cart products to decrease the quanitity (stock) of products in the database.
        /// </summary>
        public void DecreaseQuanitity()
        {
            int productId = 1;
            foreach (var product in _products)
            {
                product.Stock -= _productQuantity[productId - 1];
                _productController.UpdateProduct(product);
                productId++;
            }
        }

        /// <summary>
        /// Checks if the cart has no products. Returns true if the count is 0.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (_products.Count == 0) return true;
            else return false;
        }
    }
}