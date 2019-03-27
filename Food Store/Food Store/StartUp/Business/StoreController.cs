using System.Data.SqlClient;
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
    }
}