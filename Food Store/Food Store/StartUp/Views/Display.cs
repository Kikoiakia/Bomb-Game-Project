using StartUp.Data;
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
