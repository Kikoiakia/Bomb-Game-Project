using StartUp.Data.Models;

namespace StartUp.Data.Interfaces
{
    public interface IEmployeeController
    {
        void AddEmployee(Employee employee);
        void ChangeSalary(int storeId, double percent);
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
    }
}