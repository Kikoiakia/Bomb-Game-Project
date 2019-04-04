using System;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    /// <summary>
    /// Class used to show the user purchase menu.
    /// </summary>
    public class PurchaseMenu
    {
        /// <summary>
        /// Used to shows the purchase menu.
        /// </summary>
        /// <param name="cart"></param>
        public void Purchase(Cart cart)
        {
            string command = "";
            if (cart.GetPrice() == 0)
            {
                Console.WriteLine("Your cart is empty. You can't buy anything");
                command = "no";
            }

            while(command.ToUpper() != "NO" && command.ToUpper() != "N")
            {
                Console.WriteLine($"Total Price: {cart.GetPrice():f2}$\n" +
                                  $"Confirm Purchase Y/N?");
                Console.Beep(500, 100);
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
            }

        }
    }
}