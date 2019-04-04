using System;
using StartUp.Business;
using StartUp.Data.Models;

namespace StartUp.Views.Menus.Admin_Menus
{
    /// <summary>
    /// Class used to show the Store Managment Menu
    /// </summary>
    public class StoreManagment
    {
        /// <summary>
        /// Shows the Store Managment
        /// </summary>
        public void ShowStoreManagment()
        {
            string[] command;
            var storeController = new StoreController();
            do
            {
                Console.WriteLine("Store managment Menu:\n" +
                                  "Current Stores:\n");
                var stores = storeController.GetStore();

                if (stores.Count == 0)
                {
                    Console.WriteLine("There are no stores in the database");
                    Console.WriteLine("B. Exit Managment Menu\n\n");
                    command = Console.ReadLine()?.Split(' ');
                }
                else
                {
                    foreach (var store in stores)
                    {
                        Console.WriteLine($"ID:{store.Id}\t " +
                                          $"Name:{store.Name}\t ");
                    }

                    Console.WriteLine("\nTo add a new store use ADD");
                    Console.WriteLine("To remove a store use DELETE (Store ID)");
                    Console.WriteLine("To update a store use UPDATE");
                    Console.WriteLine("If you want to delete the whole store table and reset it's id use DELETEALL");
                    Console.WriteLine("B. Exit Managment Menu\n\n");

                    Console.Beep(500, 100);
                    command = Console.ReadLine()?.Split();

                    if (command?[0].ToUpper() == "ADD")
                    {
                        Console.Write("Store Name: ");
                        var name = Console.ReadLine();

                        var store = new Store(name);
                        try
                        {
                            storeController.AddStore(store);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Press B to go back");
                            var dummy = Console.ReadLine();
                        }
                        
                    }

                    if (command?[0].ToUpper() == "DELETE")
                    {
                        try
                        {
                            storeController.DeleteStore(int.Parse(command[1]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Press B to go back");
                            var dummy = Console.ReadLine();
                        }
                        
                    }

                    if (command?[0].ToUpper() == "UPDATE")
                    {
                        Console.Write("Store ID: ");
                        var id = int.Parse(Console.ReadLine());
                        var store = storeController.GetStore(id);

                        Console.Write("Store Name: ");
                        store.Name = Console.ReadLine();
                        
                        try
                        {
                            storeController.UpdateStore(store);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Press B to go back");
                            var dummy = Console.ReadLine();
                        }
                        
                    }

                    if (command?[0].ToUpper() == "DELETEALL")
                    {
                        Console.WriteLine("ARE YOU SURE? Y/N");
                        command = Console.ReadLine()?.Split();
                        if (command?[0].ToUpper() == "YES" || command?[0].ToUpper() == "Y")
                        {
                            foreach (var store in stores)
                            {
                                storeController.DeleteStore(store.Id);
                            }

                            storeController.ResetWholeStore();
                            Console.WriteLine("It is done. The whole table has been reset");
                        }
                    }

                }

                Console.Clear();

                    

            } while (command?[0].ToUpper() != "B");
        }
    }
}