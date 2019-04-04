using System.Collections.Generic;
using StartUp.Data.Models;

namespace StartUp.Data.Interfaces
{
    /// <summary>
    /// Interface for the product controller
    /// </summary>
    public interface IProdcutController
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void ResetWholeProduct();
    }
}