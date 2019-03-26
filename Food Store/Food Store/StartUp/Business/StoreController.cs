using System.Data.SqlClient;
using System.Web.Mvc;
using StartUp.Data;
using StartUp.Data.Models;

namespace StartUp.Business
{
    public class StoreController : Controller
    {
       private SqlConnection dbCon = new SqlConnection(Configuration.ConnectionString);
        private FoodStoreContext context;

        public StoreController()
        {
            this.context = new FoodStoreContext();
        }

        public void AddStore(Store store)
        {
          
        }
    }
}