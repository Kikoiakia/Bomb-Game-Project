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
    public class StoreServiceTests
    {
        
        [TestCase]
        public void GetAllStoresCheker()
        {
            var data = new List<Store>

            {
                new Store("billa"),
                new Store("lidl"),
                new Store("metro")

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Store>>();
            mockSet.As<IQueryable<Store>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Store>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Store>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Store>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Stores).Returns(mockSet.Object);

            var service = new StoreController(mockContext.Object);
            data.ToList().ForEach(p => service.AddStore(p));
            Assert.AreEqual(data.ToList(), service.GetStore()
                , "GetStore doesnt return right list of stores");

        }
        [TestCase]
        public void GetStoreByGivenId()
        {
            var data = new List<Store>

            {
                new Store("billa"),
                new Store("lidl"),
                new Store("metro")

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Store>>();
            mockSet.As<IQueryable<Store>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Store>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Store>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Store>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Stores).Returns(mockSet.Object);

            var service = new StoreController(mockContext.Object);
            data.ToList().ForEach(p => service.AddStore(p));
            var expected = service.GetStore(1);//billa
            Assert.AreEqual(expected,data.FirstOrDefault(x=>x.Id==1)
                , "GetStore by given id doesn't return right store. Check StoreiD!");

        }

    }
}
