using System;
using StartUp.Data;

namespace StartUp.Views.Menus
{
    public class PurchaseMenu
    {

        public void Purchase(Cart cart)
        {
            string command;
            do
            {
                Console.WriteLine($"Total Price: {cart.GetPrice():f2}$\n" +
                                  $"Confirm Purchase Y/N?");
                command = Console.ReadLine();
                if (command.ToUpper() == "Y" || command.ToUpper() == "YES")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for your purchase!");
                    cart.DecreaseQuanitity();
                    cart.RemoveProductsFromCart();
                    break;
                }

                Console.Clear();
            } while (command.ToUpper() != "N" && command.ToUpper() != "NO");

        }
    }
}