using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Interfaces;
using StartUp.Data.Models;

namespace StartUp.Business
{
    /// <summary>
    /// Controller class to control the product table in the databse
    /// </summary>
    public class ProductController : Controller, IProdcutController
    {
        /// <summary>
        /// Connection do be used to control the databse
        /// </summary>
        private readonly SqlConnection _dbCon = new SqlConnection(Configuration.ConnectionString);

        /// <summary>
        /// Context used to control the databse
        /// </summary>
        private readonly FoodStoreContext _context;

        /// <summary>
        /// Public constructor. Creates new food store context
        /// </summary>
        public ProductController()
        {
            this._context = new FoodStoreContext();
        }

        /// <summary>
        /// Returns all products from the database as a list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        /// <summary>
        /// Returns all products from given store with given id as a list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Product> GetAllProducts(int id)
        {
            List<Product> list = new List<Product>();

            foreach (var product in GetAllProducts())
            {
                if(product.ProductStoreId == id) 
                    list.Add(product);
            }

            return list;
        }

        /// <summary>
        /// Returns a specific product by given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            this._context.Products.Add(product);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Updates a product in the database
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            var productItem = this.GetProduct(product.Id);
            this._context.Entry(productItem).CurrentValues.SetValues(product);
            this._context.SaveChanges();
        }


        /// <summary>
        /// Deletes product from the database by given Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            var productItem = this.GetProduct(id);
            this._context.Products.Remove(productItem);
            this._context.SaveChanges();
        }


        /// <summary>
        /// Resets the colume id back to 0
        /// </summary>
        public void ResetWholeProduct()
        {
            
            _dbCon.Open();
            using (_dbCon)
            {
                string sqlCommand = $"USE FoodStore DBCC CHECKIDENT('Products', Reseed, 0);";
                SqlCommand command = new SqlCommand(sqlCommand, _dbCon);
                command.ExecuteNonQuery();
            }
        }
       

    }
}