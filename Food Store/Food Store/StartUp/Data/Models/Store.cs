using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace StartUp.Data.Models
{
  public class Store
    {
        public int Id { get; set; }


        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
