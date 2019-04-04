using System;

namespace StartUp.Views.Menus.Admin_Menus
{
    /// <summary>
    /// Class used to show the admin menu (aka the store managment menu).
    /// </summary>
    public class ManagmentMenu
    {
        /// <summary>
        /// Shows the managment menu.
        /// </summary>
        public void ShowManagmentMenu()
        {
            string command;
            do
            {
                Console.WriteLine("Managment Menu:\n" +
                                  "1. Manage Products\n" +
                                  "2. Manage Employees\n" +
                                  "3. Store Menu\n\n" +
                                  "B. Exit Managment Menu\n\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();

                if(command == "1") new ProductManagment().ShowProductManagment();
                if (command == "2") new EmployeeManagment().ShowEmployeeManagment();
                if (command == "3") new StoreManagment().ShowStoreManagment();


            } while (command?.ToUpper() != "B");
        }
    }
}