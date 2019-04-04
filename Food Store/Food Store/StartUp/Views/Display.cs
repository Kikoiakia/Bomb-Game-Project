using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;
using StartUp.Business;
using StartUp.Data;
using StartUp.Views.Menus;
using StartUp.Views.Menus.User_Menus;

namespace StartUp.Views
{
    /// <summary>
    /// Class used to show the app's console display.
    /// </summary>
    public class Display
    {
        /// <summary>
        /// Constructor which makes a new shopping cart and runs the program.
        /// </summary>
        public Display()
        { 
            var cart = new Cart();
            Run(cart);
        }

        /// <summary>
        /// Used to run the display.
        /// </summary>
        /// <param name="cart"></param>
        private static void Run(Cart cart)
        {
            new MainMenu().ShowMainMenu(cart);
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
