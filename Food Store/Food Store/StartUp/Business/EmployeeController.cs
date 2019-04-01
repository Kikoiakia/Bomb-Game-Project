using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Models;

namespace StartUp.Business
{
    class EmployeeController : Controller
    {
        private SqlConnection _dbCon = new SqlConnection(Configuration.ConnectionString);
        private FoodStoreContext context;

        public EmployeeController()
        {
            this.context = new FoodStoreContext();

        }


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


        //increases the salary of every employee in the store with this ID
        public void StoreSalaryIncreasement(int storeId, double percent)
        {
            foreach (var emp in this.context.Employees)
            {
                if (emp.StoreId==storeId)
                {
                    emp.Salary = emp.Salary + emp.Salary * percent / 100;
                    
                }

               
            }
            this.context.SaveChanges();
        }
        //decreases the salary of every employee in the store with this ID
        public void StoreSalaryDecrease(int storeId, double percent)
        {
            foreach (var emp in this.context.Employees)
            {
                if (emp.StoreId == storeId)
                {
                    emp.Salary = emp.Salary - emp.Salary * percent / 100;

                }


            }
            this.context.SaveChanges();
        }


        public Employee GetEmployee(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            var EmplyeeItem = this.GetEmployee(id);
            this.context.Employees.Remove(EmplyeeItem);
            this.context.SaveChanges();
        }


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
