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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

<<<<<<< HEAD
=======
        [Required]
        public int Capacity { get; set; }
        
>>>>>>> 9bf4e343a0697c491366b70eb14b206f8a9c24d9
        public List<Product> Products { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
