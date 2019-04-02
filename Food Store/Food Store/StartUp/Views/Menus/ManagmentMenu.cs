using System;

namespace StartUp.Views.Menus
{
    public class ManagmentMenu
    {
        public void ShowManagmentMenu()
        {
            string command = "Dzivev";
            do
            {
                Console.WriteLine("Managment Menu:\n" +
                                  "1. Stock Menu\n" +
                                  "2. Get Employees\n" +
                                  "3. Store Menu\n\n" +
                                  "B. Exit Managment Menu\n\n");
                Console.Beep(500, 100);
                command = Console.ReadLine();
                Console.Clear();

            } while (command.ToUpper() != "B");
        }
    }
}