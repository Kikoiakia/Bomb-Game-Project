using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Models;

namespace StartUp.Business
{
    public class ProductController : Controller
    {

        private SqlConnection _dbCon = new SqlConnection(Configuration.ConnectionString);
        private FoodStoreContext context;

        public ProductController()
        {
            this.context = new FoodStoreContext();
        }

        /// <summary>
        /// Returns all products from the database as a list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        /// <summary>
        /// Gets a specific product by given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates a product in the database
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            var productItem = this.GetProduct(product.Id);
            this.context.Entry(productItem).CurrentValues.SetValues(product);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes product from the database by given Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            var productItem = this.GetProduct(id);
            this.context.Products.Remove(productItem);
            this.context.SaveChanges();
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