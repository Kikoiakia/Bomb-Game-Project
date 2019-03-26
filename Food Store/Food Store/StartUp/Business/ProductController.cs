using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }
            
        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productItem = this.GetProduct(product.Id);
            this.context.Entry(productItem).CurrentValues.SetValues(product);
            this.context.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            var productItem = this.GetProduct(Id);
            this.context.Products.Remove(productItem);
            this.context.SaveChanges();
        }

        public void ResetWholeProduct()
        {
            
            _dbCon.Open();
            using (_dbCon)
            {
                string sqlCommand = $"USE FoodStore;/n" +
                                    $"GO/n" +
                                    $"DBCC CHECKIDENT('Products', Reseed, 0);";
            }
        }
       

    }
}