using System;
using StartUp.Data;

namespace StartUp.Views.Menus
{
    public class CartMenu
    {
        public void ShowCart(Cart cart)
        {
            string[] commandArgs;
            do
            {
                Console.WriteLine($"Cart:\n");
                cart.ShowProductsInCart();
                Console.WriteLine($"\nPress B to go Back");
                Console.Beep(500, 100);

                commandArgs = Console.ReadLine().Split(' ');
                Console.Clear();

            } while (commandArgs[0].ToUpper() != "B");
            
            
        }
    }
}

/*
 * The cart menu will give acces to the user to view his products and to remove a product from the cart
 */