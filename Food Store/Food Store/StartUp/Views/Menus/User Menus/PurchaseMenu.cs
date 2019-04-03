using System;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    public class PurchaseMenu
    {

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