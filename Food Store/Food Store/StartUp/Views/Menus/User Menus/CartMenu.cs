using System;
using StartUp.Data;

namespace StartUp.Views.Menus.User_Menus
{
    /// <summary>
    /// Class used to display the cart menu.
    /// </summary>
    public class CartMenu
    {
        /// <summary>
        /// Shows the cart console menu.
        /// </summary>
        /// <param name="cart"></param>
        public void ShowCart(Cart cart)
        {

            string[] commandArgs;
            
            do
            {
                Console.WriteLine($"Cart:\n");
                cart.ShowProductsInCart();
                Console.WriteLine($"\nUse Remove (number) to remove an item from the cart");
                Console.WriteLine($"\nPress B to go Back");
                Console.Beep(500, 100);
                
                commandArgs = Console.ReadLine().Split(' ');
                if(commandArgs[0].ToUpper() == "REMOVE")
                {
                    var index = int.Parse(commandArgs[1]);
                    cart.RemoveProductFromCart(index);
                }
                Console.Clear();

            } while (commandArgs[0].ToUpper() != "B");
            
            
        }
    }
}

/*
 * The cart menu will give acces to the user to view his products and to remove a product from the cart
 */