using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StartUp.Data;
using StartUp.Data.Models;
using StartUp.Business;

namespace Tests
{
    public class EmployeeServiceTests
    {
        [TestCase]
        public void GetAllEmployees()
        {
            var data = new List<Employee>

            {
                new Employee("Tosho tOSHOV", 2353,1),
                new Employee("gOSHO",2300,2),
                new Employee("TOSHOV", 100,3)

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeController(mockContext.Object);
            data.ToList().ForEach(p => service.AddEmployee(p));
            Assert.AreEqual(service.GetAllEmployees(), data.ToList(),
                "GetAllEmployee doesn't work right");

        }
        [TestCase]
        public void GetAllEmployeesOfStoreByGivenStoredID()
        {
            var data = new List<Employee>

            {
                new Employee("Tosho tOSHOV", 2353,1),
                new Employee("gOSHO",2300,2),
                new Employee("TOSHOV", 100,3),
                new Employee("TOSHeV", 100,1)


            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeController(mockContext.Object);
            data.ToList().ForEach(p => service.AddEmployee(p));
            var expected = service.GetAllEmployeesOfStore(1);


            Assert.AreEqual(expected, data.Where(x => x.StoreId == 1).ToList(),
                "GetAllEmployeesOfStoreByGivenStoredID doesn't" +
                " return right list of employees by give storeID");

        }
        [TestCase]
        public void GetEmployeeById()
        {
            var data = new List<Employee>

            {
                new Employee("Tosho tOSHOV", 2353,1),
                new Employee("gOSHO",2300,2),
                new Employee("TOSHOV", 100,3)

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeController(mockContext.Object);
            data.ToList().ForEach(p => service.AddEmployee(p));
            var expected = service.GetEmployee(1);
            Assert.AreEqual(expected, data.FirstOrDefault(x => x.Id == 1),
                "GetEmployeeByID doesn't return right employee.Check if Id contains!");

        }

        [TestCase]
        public void ChangeSalaryByGivenEmployeeIdAndPercentAmount()
        {
            var data = new List<Employee>

            {
                new Employee("Tosho tOSHOV", 2353,1),
                new Employee("gOSHO",2300,2),
                new Employee("TOSHOV", 100,3)

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<FoodStoreContext>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeController(mockContext.Object);
            data.ToList().ForEach(p => service.AddEmployee(p));
            service.ChangeSalary(3, 25); //TOSHOV id=3
            const double expected = 125;
            var actual = service.GetEmployee(3).Salary;
            
            Assert.AreEqual(expected, actual,
                "ChangeSalary doesn't changed " +
                "employee salary.Check if iD of EMployee is correct!");
           
        }



    }
}
