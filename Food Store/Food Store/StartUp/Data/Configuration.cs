namespace StartUp.Data
{
    /// <summary>
    /// Configuration class used to connect to the database
    /// </summary>
   public static class Configuration
   {
       /// <summary>
       /// Public string used to store the connection to the database.
       /// </summary>
       public const string ConnectionString = "Server=KIRIL-LAPTOP" +
                                              "\\SQLEXPRESS;" +
                                              "Database=FoodStore;" +
                                              "Integrated Security=True";

       
   }
}
