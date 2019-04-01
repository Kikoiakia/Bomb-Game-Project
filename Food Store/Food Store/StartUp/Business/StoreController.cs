using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Models;

namespace StartUp.Business
{
    public class StoreController : Controller
    {
        private SqlConnection _dbCon = new SqlConnection(Configuration.ConnectionString);
        private FoodStoreContext _context;

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



        public Store GetStore(int id)
        {
            var store = _context.Stores.FirstOrDefault(x => x.Id == id);
            return store;
        }

        public void DeleteStore(int id)
        {
            var StoreItem = this.GetStore(id);
            this._context.Stores.Remove(StoreItem);
            this._context.SaveChanges();
        }


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