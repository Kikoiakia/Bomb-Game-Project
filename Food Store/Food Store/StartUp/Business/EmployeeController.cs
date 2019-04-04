using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Interfaces;
using StartUp.Data.Models;

namespace StartUp.Business
{
    /// <summary>
    /// Controller class to control the employee table in the databse
    /// </summary>
    class EmployeeController : Controller , IEmployeeController
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
        /// Public Constructor. Creates new food store context
        /// </summary>
        public EmployeeController()
        {
            _context = new FoodStoreContext();

        }

        /// <summary>
        /// Adds Employee to the database
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            try
            {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Store Id");
                
            }
      
            
        }

        /// <summary>
        /// Updates an employee from the DB
        /// </summary>
        /// <param name="employee"></param>
        public void UpdateEmployee(Employee employee)
        {
            var newEmployee = GetEmployee(employee.Id);
            _context.Entry(newEmployee).CurrentValues.SetValues(employee);
            _context.SaveChanges();
        }

        /// <summary>
        /// Changes Salary with given percent
        /// </summary>
        /// <param name="id"></param>
        /// <param name="percent"></param>
        public void ChangeSalary(int id, double percent)
        {
            foreach (var emp in _context.Employees)
            {
                if (emp.Id == id)
                {
                    emp.Salary = emp.Salary + emp.Salary * percent / 100;
                    UpdateEmployee(emp);
                }


            }
            _context.SaveChanges();
        }


        /// <summary>
        /// Returns a specific employee with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        /// <summary>
        /// Returns a list of all employees in the DB
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        /// <summary>
        /// Delets an Employee with given ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            var emplyeeItem = GetEmployee(id);
            _context.Employees.Remove(emplyeeItem);
            _context.SaveChanges();
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
                const string sqlCommand = "USE FoodStore DBCC CHECKIDENT('Employees', Reseed, 0);";
                SqlCommand command = new SqlCommand(sqlCommand, _dbCon);
                command.ExecuteNonQuery();
            }
        }

    }
}
