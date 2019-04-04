using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Interfaces;
using StartUp.Data.Models;

namespace StartUp.Business
{
    /// <summary>
    /// Controller class to control the store table in the databse
    /// </summary>
    public class StoreController : Controller , IStoreController
    {
        /// <summary>
        /// Connection do be used to control the databse
        /// </summary>
        private readonly SqlConnection _dbCon = new SqlConnection(Configuration.ConnectionString);

        /// <summary>
        /// Context used to control the databse
        /// </summary>
        private readonly FoodStoreContext _context;

        /// <summary>
        /// Public contstructor. Creates new food store context.
        /// </summary>
        public StoreController()
        {
            this._context = new FoodStoreContext();
        }

        /// <summary>
        /// Add a new store to the database
        /// </summary>
        /// <param name="store"></param>
        public void AddStore(Store store)
        {
            this._context.Stores.Add(store);
            _context.SaveChanges();
        }

        /// <summary>
        /// Returns all stores as a list
        /// </summary>
        /// <returns></returns>
        public List<Store> GetStore()
        {
              return _context.Stores.ToList();
        }

        /// <summary>
        /// Returns a store with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Store GetStore(int id)
        {
            var store = _context.Stores.FirstOrDefault(x => x.Id == id);
            return store;
        }

        /// <summary>
        /// Deletes a store with given ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteStore(int id)
        {
            var StoreItem = this.GetStore(id);
            this._context.Stores.Remove(StoreItem);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Resets the id for the stores in the database. Use only when you are clearing the database.
        /// </summary>
        public void ResetWholeStore()
        {

            _dbCon.Open();
            using (_dbCon)
            {
                string sqlCommand = $"USE FoodStore DBCC CHECKIDENT('Stores', Reseed, 0);";
                SqlCommand command = new SqlCommand(sqlCommand, _dbCon);
                command.ExecuteNonQuery();
            }
        }

    }
}