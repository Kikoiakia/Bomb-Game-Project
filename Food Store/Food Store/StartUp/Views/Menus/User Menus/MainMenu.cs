
using System;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    /// <summary>
    /// Class used to show the main menu when opening the app as a user.
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// Shows the user main menu.
        /// </summary>
        /// <param name="cart"></param>
        public void ShowMainMenu(Cart cart)
        {
            var command = "";
            do
            {
                
                Console.WriteLine("Main Menu:\n" +
                                  "1. Select Store\n\n" +
                                  "2. Check Cart\n" +
                                  "3. Confirm Purchase\n\n" +
                                  "Q. Exit Programm\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();


                if (command == "Dzivev")
                {
                    new ManagmentMenu().ShowManagmentMenu();
                }

                if (command == "1")
                {
                    new StoreMenu().SelectStore(cart);
                }

                if (command == "2")
                {
                    new CartMenu().ShowCart(cart);
                }

                if (command == "3")
                {
                    new PurchaseMenu().Purchase(cart);
                }

                if (command.ToUpper() == "Q") break;

            } while (true);

            Console.Clear();
            Console.WriteLine("Goodbye");
            Console.Beep(500, 100);

        }
    }
}