using System;
using StartUp.Data;

namespace StartUp.Views.Menus
{
    public class MainMenu
    {
        public void ShowMainMenu(Cart cart)
        {
            string command = "";
            do
            {
                
                Console.WriteLine("Main Menu:\n" +
                                  "1. Select Store\n\n" +
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

                if (command.ToUpper() == "Q") break;

            } while (true);

            Console.Clear();
            Console.WriteLine("Goodbye");
            Console.Beep(500, 100);

        }
    }
}