using System;
using StartUp.Business;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    /// <summary>
    /// Class used to select a store and to show it's available menu options to the user.
    /// </summary>
    public class StoreMenu
    {
        /// <summary>
        /// Shows the user available stores to select from.
        /// </summary>
        /// <param name="cart"></param>
        public void SelectStore(Cart cart)
        {
            string command;
            do
            {
                Console.WriteLine("Availabe Stores:\n");
                var stores = new StoreController().GetStore();
                if (stores.Count == 0)
                {
                    Console.WriteLine("There are no available stores");
                    Console.WriteLine("\nPress B to go Back");
                    command = Console.ReadLine();
                }
                else
                {
                    foreach (var store in stores)
                    {
                        Console.WriteLine($"{store.Id}. {store.Name}");
                    }

                    Console.WriteLine("\nB. Go Back\n");
                    Console.Beep(500, 100);
                    command = Console.ReadLine();
                    try
                    {
                        ShowStoreMenu(int.Parse(command), cart);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            } while (command?.ToUpper() != "B");
            Console.Clear();
        }

        /// <summary>
        /// Shows the user the selected store menu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cart"></param>
        private static void ShowStoreMenu(int id, Cart cart)
        {

            Console.Clear();
            string command;
            do
            {
                Console.WriteLine("Store Menu:\n" +
                                  "1. Select Stock\n" +
                                  "B. Go Back\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();

                if (command == "1")
                {
                    new StockMenu().ShowStock(id, cart);
                }

            } while (command?.ToUpper() != "B");
        }
    }
}