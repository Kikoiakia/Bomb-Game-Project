using System.Collections.Generic;
using StartUp.Data.Models;

namespace StartUp.Data.Interfaces
{
    /// <summary>
    /// Interface for the store controller
    /// </summary>
    public interface IStoreController
    {
        void AddStore(Store store);
        List<Store> GetStore();
        void DeleteStore(int id);
        void ResetWholeStore();
    }
}