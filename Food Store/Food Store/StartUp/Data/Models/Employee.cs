using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StartUp.Data.Models
{
   public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Required]
        [MaxLength(25)]
        public string FullName { get; set; }

        [Range(0,20000,
            ErrorMessage =
            "Salary should be greater than 0 or equal to 0 and lower than 20000")]
        public double Salary { get; set; }

      
       
        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}
