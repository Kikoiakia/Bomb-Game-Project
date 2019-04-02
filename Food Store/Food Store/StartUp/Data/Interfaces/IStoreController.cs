using System.Collections.Generic;
using StartUp.Data.Models;

namespace StartUp.Data.Interfaces
{
    public interface IStoreController
    {
        void AddStore(Store store);
        List<Store> GetStore();
        void DeleteStore(int id);
        void ResetWholeStore();
    }
}