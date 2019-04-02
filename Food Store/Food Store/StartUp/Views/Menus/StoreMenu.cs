using System;
using StartUp.Business;
using StartUp.Data;

namespace StartUp.Views.Menus
{
    public class StoreMenu
    {
        public void SelectStore(Cart cart)
        {
            string command = "1";
            do
            {
                Console.WriteLine("Availabe Stores:\n");
                var Stores = new StoreController().GetStore();
                foreach (var store in Stores)
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

            } while (command.ToUpper() != "B");
            Console.Clear();
        }

        private void ShowStoreMenu(int id, Cart cart)
        {

            Console.Clear();
            string command = "1";
            do
            {
                Console.WriteLine("Store Menu:\n" +
                                  "1. Select Stock\n" +
                                  "2. Check Cart\n" +
                                  "3. Confirm Purchase\n\n" +
                                  "B. Go Back\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();

                if (command == "1")
                {
                    new StockMenu().ShowStock(id, cart);
                }

                if (command == "2")
                {
                    new CartMenu().ShowCart(cart);
                }

                if (command == "3")
                {
                    new PurchaseMenu().Purchase(cart);
                }

            } while (command.ToUpper() != "B");
        }
    }
}