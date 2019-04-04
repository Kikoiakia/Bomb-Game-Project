using System;
using StartUp.Business;
using StartUp.Data.Models;

namespace StartUp.Views.Menus.Admin_Menus
{
    /// <summary>
    /// Class used to show the Employee managment menu
    /// </summary>
    public class EmployeeManagment
    {
        /// <summary>
        /// Shows the Employee Managment Menu
        /// </summary>
        public void ShowEmployeeManagment()
        {
            string[] command;
            var employeeController = new EmployeeController();
            do
            {
                Console.WriteLine("Employee managment Menu:\n" +
                                  "Current Employees:\n");
                var employees = employeeController.GetAllEmployees();
                if (employees.Count == 0)
                {
                    Console.WriteLine("There are no products");
                    Console.WriteLine("Use Add to add a new employee");
                    Console.WriteLine("B. Exit Managment Menu\n\n");
                    command = Console.ReadLine()?.Split(' ');
                    if (command?[0].ToUpper() == "ADD") AddEmployee(employeeController);
                }

                else
                {


                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID:{employee.Id}\t " +
                                          $"Name:{employee.FullName}\t " +
                                          $"Salary:{employee.Salary}\t " +
                                          $"Store ID:{employee.StoreId}");
                    }

                    Console.WriteLine("\nTo add a new employee use ADD");
                    Console.WriteLine("To remove a employee use DELETE (Employee ID)");
                    Console.WriteLine("To update a employee use UPDATE");
                    Console.WriteLine("To change an employee's salary use CHANGE");
                    Console.WriteLine("If you want to delete the whole empoloyee table and reset it's id use DELETEALL");
                    Console.WriteLine("B. Exit Managment Menu\n\n");

                    Console.Beep(500, 100);
                    command = Console.ReadLine()?.Split();

                    if (command?[0].ToUpper() == "ADD")
                    {
                        AddEmployee(employeeController);

                    }

                    if (command?[0].ToUpper() == "DELETE")
                    {
                        employeeController.DeleteEmployee(int.Parse(command[1]));
                    }

                    if (command?[0].ToUpper() == "UPDATE")
                    {
                        Console.Write("Employee full name: ");
                        var name = Console.ReadLine();

                        Console.Write("Employee Salary: ");
                        var salary = double.Parse(Console.ReadLine());

                        Console.Write("In which store is the employee assigned to (use store id): ");
                        var employeeStoreId = int.Parse(Console.ReadLine());

                        var employee = new Employee(name, salary, employeeStoreId);
                        try
                        {
                            employeeController.UpdateEmployee(employee);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Press B to go back");
                            var dummy = Console.ReadLine();
                        }
                    }

                    if (command?[0].ToUpper() == "CHANGE")
                    {
                        Console.Write("Employee ID: ");
                        var id = int.Parse(Console.ReadLine());

                        Console.Write("With how much (in percentage): ");
                        var percentage = double.Parse(Console.ReadLine());
                        try
                        {
                            employeeController.ChangeSalary(id, percentage);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Press B to go back");
                            var dummy = Console.ReadLine();
                        }
                        
                    }

                    if (command?[0].ToUpper() == "DELETEALL")
                    {
                        Console.WriteLine("ARE YOU SURE? Y/N");
                        command = Console.ReadLine()?.Split();
                        if (command?[0].ToUpper() == "YES" || command?[0].ToUpper() == "Y")
                        {
                            foreach (var employee in employees)
                            {
                                employeeController.DeleteEmployee(employee.Id);
                            }

                            employeeController.ResetWholeEmployee();
                            Console.WriteLine("It is done. The whole table has been reset");
                        }
                    }

                }

                Console.Clear();

               

            } while (command?[0].ToUpper() != "B");
        }

        private static void AddEmployee(EmployeeController employeeController)
        {
            Console.Write("Employee full name: ");
            var name = Console.ReadLine();

            Console.Write("Employee Salary: ");
            var salary = double.Parse(Console.ReadLine());

            Console.Write("In which store is the employee assigned to (use store id): ");
            var employeeStoreId = int.Parse(Console.ReadLine());

            var employee = new Employee(name, salary, employeeStoreId);

            try
            {
                employeeController.AddEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Press B to go back");
                var dummy = Console.ReadLine();
            }
        }
    }
}