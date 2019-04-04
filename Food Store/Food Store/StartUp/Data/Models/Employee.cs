using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartUp.Data.Models
{
    /// <summary>
    /// Public class for creating new employees
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Public constructor. Used to take employee's full name, salary and store id he/she is assinged to.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="salary"></param>
        /// <param name="storeId"></param>
        public Employee(string fullName,double salary,int storeId)
        {
            FullName = fullName;
            Salary = salary;
            StoreId = storeId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Required]
        [MaxLength(25)]
        public string FullName { get; set; }

        [Range(0,21000,
            ErrorMessage =
            "Salary should be greater than 0 or equal to 0 and lower than 21000")]
        public double Salary { get; set; }

      
       
        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}
