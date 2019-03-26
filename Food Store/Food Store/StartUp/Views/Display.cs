using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;

namespace StartUp.Views
{
    public class Display
    {
        public Display()
        {
            Program();
        }

        public void Program()
        {
            string command = "";
            do
            {
                Console.WriteLine("Main Menu:\n" +
                                  "1. Select Store\n" +
                                  "2. Exit Programm\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();


                if (command == "Dzivev")
                {
                    ShowManagmentMenu();
                }

                if (command == "1")
                {
                    SelectStore();
                }

                if (command == "2") break;

            } while (true);
            Console.Clear();
            Console.WriteLine("Goodbye");
            Console.Beep(500, 100);
           
        }

        private void ShowManagmentMenu()
        {
            string command = "Dzivev";
            do
            {
                Console.WriteLine("Managment Menu:\n" +
                                  "1. Stock Menu\n" +
                                  "2. Get Employees\n" +
                                  "3. Store Menu\n" +
                                  "4. Exit Managment Menu\n\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();

            } while (command != "4");
        }

        private void SelectStore()
        {
            string command = "1";
            do
            {
                Console.WriteLine("Store Menu:\n" +
                                  "1. Select Stock\n" +
                                  "2. Add Stock to Cart\n" +
                                  "3. Check Cart\n" +
                                  "4. Go Back\n\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();


            } while (command != "4");
        }
    }
}

/*
 *  Main Menu:
 *  1. Select Store
 *  ------Store Managment-------- (a special code needs to be entered to acces this menu. Pass: ["Dzivev"])
 *  2. Get Employees
 *  3. Stock Menu
 *
 */

/*
 *  Store Menu(2):
 *  1.View Stock
 *  2.Add Stock to cart
 *  3.Check Cart
 *  4.Go Back
 */

/*
 *  Employee Menu(2):
 *  1.Get new employee
 *  2.Check an employee
 *  3.Update an employee
 *  4.Delete an employee
 *  5.Go Back
 */

/*
 *  Stock Menu(3):
 *  1.Restock Stock
 *  2.Get new Stock
 *  3.Remove Stock
 *  4.Go Back
 */
