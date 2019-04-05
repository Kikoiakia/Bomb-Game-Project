using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StartUp.Business;
using StartUp.Data;
using StartUp.Data.Models;

namespace Tests
{
   public  class ProductServiceTests
    {
        [TestCase]
        public void GetAllProductsCheck()
        {
            var data = new List<Product>
            {
                new Product("banan", 1.99, 3, DateTime.Now, 1),
                new Product("chokolad", 3.45, 3, DateTime.Now, 1),
                new Product("kiwi", 4, 1, DateTime.Now, 1)
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p=>service.AddProduct(p));
            service.GetAllProducts();

        }

        [TestCase]
        public void GetProductByIdCheck()
        {
            var data = new List<Product>
            {
                new Product("banan", 1.99, 3, DateTime.Now, 1),
                new Product("chokolad", 3.45, 3, DateTime.Now, 2),
                new Product("kiwi", 4, 1, DateTime.Now, 3)
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.AddProduct(p));
            var expected = service.GetProduct(1); // banan
            Assert.AreEqual(expected, data.FirstOrDefault(x=>x.Id==1),
                "GetProduct method doesn't return right product. Check id!");
        }


        [TestCase]
        public void GetAllProductsOfStoreByGivenStoreId()
        {
            var data = new List<Product>
            {
                new Product("banan", 1.99, 3, DateTime.Now, 1),
                new Product("chokolad", 3.45, 3, DateTime.Now, 2),
                new Product("kiwi", 4, 1, DateTime.Now, 3),
                new Product("PANDISHPAN",3.21, 4, DateTime.Now, 1)

            }.AsQueryable();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var service = new ProductController(mockContext.Object);
            data.ToList().ForEach(p => service.AddProduct(p));
            var expected = service.GetAllProducts(1);// banan and pandishpan
            Assert.AreEqual(expected, data.Where(x=>x.ProductStoreId==1).ToList(),
                "GetALLProducts method doesn't return right products. Check ProductStoreId!");
        }
       
    }
}
