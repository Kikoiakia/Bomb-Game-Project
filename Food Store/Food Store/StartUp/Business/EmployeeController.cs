using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Interfaces;
using StartUp.Data.Models;

namespace StartUp.Business
{
    class EmployeeController : Controller , IEmployeeController
    {
        private SqlConnection _dbCon = new SqlConnection(Configuration.ConnectionString);
        private FoodStoreContext context;

        /// <summary>
        /// Public Constructor
        /// </summary>
        public EmployeeController()
        {
            this.context = new FoodStoreContext();

        }

        /// <summary>
        /// Adds Employee to the database
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            try
            {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Store Id");
                
            }
      
            
        }

        /// <summary>
        /// Changes Salary with given percent
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="percent"></param>
        public void ChangeSalary(int storeId, double percent)
        {
            foreach (var emp in this.context.Employees)
            {
                if (emp.StoreId == storeId)
                {
                    emp.Salary = emp.Salary + emp.Salary * percent / 100;

                }


            }
            this.context.SaveChanges();
        }

     
       

        /// <summary>
        /// Returns a specific employee with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        /// <summary>
        /// Delets an Employee with given ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            var EmplyeeItem = this.GetEmployee(id);
            this.context.Employees.Remove(EmplyeeItem);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Resets the the id for the employees back to 0.
        /// Use only when you clear the whole database.
        /// </summary>
        public void ResetWholeEmployee()
        {

            _dbCon.Open();
            using (_dbCon)
            {
                string sqlCommand = $"USE FoodStore DBCC CHECKIDENT('Employees', Reseed, 0);";
                SqlCommand command = new SqlCommand(sqlCommand, _dbCon);
                command.ExecuteNonQuery();
            }
        }

    }
}
