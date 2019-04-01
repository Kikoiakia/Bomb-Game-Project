using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace StartUp.Data.Models
{
  public class Store
    {

        public Store(string name)
        {
            this.Name = name;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
